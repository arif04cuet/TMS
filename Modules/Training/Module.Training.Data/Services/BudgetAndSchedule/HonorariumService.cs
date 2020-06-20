using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class HonorariumService : IHonorariumService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<HonorariumHead> _honorariumHeadRepository;
        private readonly IRepository<Honorarium> _honorariumRepository;

        public HonorariumService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _honorariumHeadRepository = _unitOfWork.GetRepository<HonorariumHead>();
            _honorariumRepository = _unitOfWork.GetRepository<Honorarium>();
        }

        public async Task<long> CreateAsync(HonorariumCreateRequest request, CancellationToken cancellationToken = default)
        {

            var exist = await _honorariumRepository
                .AsReadOnly()
                .Where(x => x.HonorariumFor == request.HonorariumFor && x.Year == request.Year && !x.IsDeleted)
                .Select(x => x.Id)
                .CountAsync(cancellationToken) > 0;

            if (exist)
                throw new ValidationException("Honorarium not available for this year.");

            var entity = request.Map();
            await _honorariumRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var heads = request.Heads.Select(x => new HonorariumHead
            {
                HonorariumId = entity.Id,
                DesignationId = x.Designation,
                Amount = x.Amount,
                Head = x.Head
            });
            await _honorariumHeadRepository.AddRangeAsync(heads);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(HonorariumUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _honorariumRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Honorarium not found");

            var exist = await _honorariumRepository
                .AsReadOnly()
                .Where(x => x.HonorariumFor == request.HonorariumFor && x.Year == request.Year && x.Id != request.Id && !x.IsDeleted)
                .Select(x => x.Id)
                .CountAsync(cancellationToken) > 0;

            if (exist)
                throw new ValidationException("Honorarium not available for this year.");

            request.Map(entity);

            foreach (var head in request.Heads)
            {
                if (head.Id.HasValue)
                {
                    var dbHead = await _honorariumHeadRepository
                        .Where(x => x.Id == head.Id.Value && !x.IsDeleted)
                        .FirstOrDefaultAsync();
                    if (dbHead != null)
                    {
                        head.Map(dbHead);
                    }
                }
                else
                {
                    // new 
                    var newHead = head.Map();
                    newHead.HonorariumId = entity.Id;
                    await _honorariumHeadRepository.AddAsync(newHead);
                }
            }

            var requestHeadIds = request.Heads.Where(x => x.Id.HasValue).Select(x => x.Id.Value);
            var headToBeDeleted = await _honorariumHeadRepository
                .Where(x => !requestHeadIds.Contains(x.Id) && x.HonorariumId == request.Id && !x.IsDeleted)
                .ToListAsync();
            _honorariumHeadRepository.RemoveRange(headToBeDeleted);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _honorariumRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Honorarium not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<HonorariumViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _honorariumRepository.GetAsync(x => x.Id == id, HonorariumViewModel.Select(), cancellationToken);

            item.Heads = await _honorariumHeadRepository
                .Where(x => x.HonorariumId == id && !x.IsDeleted)
                .Select(HonorariumHeadViewModel.Select())
                .ToListAsync();

            return item;
        }

        public async Task<PagedCollection<HonorariumViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _honorariumRepository.ListAsync(HonorariumViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        public async Task<PagedCollection<HonorariumHeadViewModel>> ListLatestYearHonorariumHeadsAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var latestHonorarium = await _honorariumRepository
                .Where(x => x.HonorariumFor == HonorariumFor.ResourcePerson && !x.IsDeleted)
                .OrderByDescending(x => x.Year)
                .FirstOrDefaultAsync();

            if (latestHonorarium == null)
                return PagedCollection<HonorariumHeadViewModel>.Empty(pagingOptions);

            Expression<Func<HonorariumHead, bool>> predicate = x => x.HonorariumId == latestHonorarium.Id && x.DesignationId == null && !x.IsDeleted;

            var result = await _honorariumHeadRepository.ListAsync(predicate, HonorariumHeadViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

    }
}
