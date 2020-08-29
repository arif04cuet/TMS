using Infrastructure;
using Infrastructure.Data;
using Module.Asset.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Module.Asset.Data
{
    public class AssetDepreciationService : IAssetDepreciationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Entities.Asset> _assetRepository;
        private readonly IRepository<AssetDepreciationRevision> _assetDepreciationRevisionRepository;
        private readonly IRepository<AssetDepreciationSchedule> _assetDepreciationScheduleRepository;

        // frequency in month
        // depreciation apply inverval
        private const int Frequency = 12;


        public AssetDepreciationService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _assetRepository = _unitOfWork.GetRepository<Entities.Asset>();
            _assetDepreciationRevisionRepository = _unitOfWork.GetRepository<AssetDepreciationRevision>();
            _assetDepreciationScheduleRepository = _unitOfWork.GetRepository<AssetDepreciationSchedule>();
        }

        public async Task<long> CreateAsync(long assetId, CancellationToken cancellationToken = default)
        {
            Entities.Asset asset = await _assetRepository.FirstOrDefaultAsync(x => x.Id == assetId && !x.HasDepreciated && !x.IsDeleted);

            if (asset == null)
                throw new ValidationException("Asset not found.");

            if (asset.EOL < Frequency)
                throw new ValidationException("EOL must be equal or greater than depreciation frequency.");

            int revisionCount = await _assetDepreciationRevisionRepository.CountAsync(x => x.AssetId == assetId && !x.IsDeleted);

            if (revisionCount > 0)
                throw new ValidationException("Revision already created");

            // calculate next depreciation apply date
            asset.NextDepreciateDate = asset.InvoiceDate.Value.Date.AddMonths(Frequency); ;

            var revision = new AssetDepreciationRevision
            {
                AssetId = asset.Id,
                EOL = asset.EOL,
                Frequency = Frequency,
                RatePerFrequency = CalculateRate((float)asset.PurchaseCost, asset.EOL),
                ValuePerFrequency = CalculateValue((float)asset.PurchaseCost, asset.EOL)
            };

            await _assetDepreciationRevisionRepository.AddAsync(revision);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var schedule = new AssetDepreciationSchedule
            {
                AssetId = asset.Id,
                AssetDepreciationId = revision.Id,
                CurrentDepreciation = 0,
                CummulativeValue = 0,
                CurrentValue = (float)asset.PurchaseCost
            };
            await _assetDepreciationScheduleRepository.AddAsync(schedule);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return revision.Id;
        }

        public async Task<long> ApplyAsync(long assetId, CancellationToken cancellationToken = default)
        {
            Entities.Asset asset = await _assetRepository.FirstOrDefaultAsync(x => x.Id == assetId && !x.HasDepreciated && x.NextDepreciateDate != null && !x.IsDeleted);

            if (asset == null)
                throw new ValidationException("Asset not found.");

            var schedules = await _assetDepreciationScheduleRepository
                .AsReadOnly()
                .Where(x => x.AssetId == asset.Id && !x.IsDeleted)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();

            var lastSchedule = schedules.LastOrDefault();

            var depreciation = await _assetDepreciationRevisionRepository
                .AsReadOnly()
                .OrderBy(x => x.CreatedAt)
                .LastOrDefaultAsync(x => x.AssetId == asset.Id && !x.IsDeleted);

            if (depreciation == null)
                throw new ValidationException("Depreciation not found");

            var currentDepreciation = lastSchedule == null ? 0 : depreciation.ValuePerFrequency;
            var cummulativeValue = lastSchedule == null ? 0 : lastSchedule.CummulativeValue + depreciation.ValuePerFrequency;
            var currentValue = lastSchedule == null ? asset.PurchaseCost : lastSchedule.CurrentValue - depreciation.ValuePerFrequency;

            if (currentValue <= 0)
            {
                // full asset value are consumed
                asset.NextDepreciateDate = null;
                asset.HasDepreciated = true;
            }
            else
            {
                // calculate next depreciation apply date
                var consumed = (schedules.Count - 1) * Frequency;
                var remaining = asset.EOL - consumed;
                var next = remaining > Frequency ? Frequency : remaining;
                asset.NextDepreciateDate = asset.NextDepreciateDate.Value.AddMonths(next);
            }

            var newSchedule = new AssetDepreciationSchedule
            {
                AssetId = asset.Id,
                AssetDepreciationId = depreciation.Id,
                CurrentDepreciation = currentDepreciation,
                CummulativeValue = cummulativeValue,
                CurrentValue = (float)currentValue
            };
            await _assetDepreciationScheduleRepository.AddAsync(newSchedule);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result;
        }

        public async Task<long> ReviseAsync(long assetId, CancellationToken cancellationToken = default)
        {
            Entities.Asset asset = await _assetRepository.FirstOrDefaultAsync(x => x.Id == assetId && !x.HasDepreciated && !x.IsDeleted);

            if (asset == null)
                throw new ValidationException("Asset not found.");

            var schedules = await _assetDepreciationScheduleRepository
                .AsReadOnly()
                .Where(x => x.AssetId == asset.Id && !x.IsDeleted)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();

            var consumedFrequency = (schedules.Count - 1) * Frequency;

            if (asset.EOL <= consumedFrequency)
                throw new ValidationException("EOL must be greater than consumed depreciation frequency.");

            var newEOL = asset.EOL - consumedFrequency;

            var lastSchedule = schedules.LastOrDefault();
            var currentValue = lastSchedule.CurrentValue;

            if (asset.EOL < Frequency)
                throw new ValidationException("EOL must be equal or greater than depreciation frequency.");

            var revision = new AssetDepreciationRevision
            {
                AssetId = asset.Id,
                EOL = asset.EOL,
                Frequency = Frequency,
                RatePerFrequency = CalculateRate(currentValue, newEOL),
                ValuePerFrequency = CalculateValue(currentValue, newEOL)
            };

            await _assetDepreciationRevisionRepository.AddAsync(revision);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return revision.Id;
        }

        private float CalculateValue(float cost, int eol)
        {
            return ((cost * Frequency) / eol);
        }

        private float CalculateRate(float cost, int eol)
        {
            var value = CalculateValue(cost, eol);
            return ((value * 100) / cost);
        }


    }
}
