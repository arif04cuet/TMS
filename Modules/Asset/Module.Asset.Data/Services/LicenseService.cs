﻿using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Asset.Entities;
using Module.Core.Shared;
using Msi.UtilityKit;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Asset.Data
{
    public class LicenseService : ILicenseService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<License> _repository;
        private readonly IRepository<LicenseSeat> _seatRepository;
        private readonly IRepository<CheckoutHistory> _checkoutHistoryRepository;

        public LicenseService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<License>();
            _seatRepository = _unitOfWork.GetRepository<LicenseSeat>();
            _checkoutHistoryRepository = _unitOfWork.GetRepository<CheckoutHistory>();

        }

        public async Task<long> CreateAsync(LicenseCreateRequest request, CancellationToken cancellationToken = default)
        {
            //create license
            var newEntity = request.ToMap();

            await _repository.AddAsync(newEntity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            //create seats
            await CreateSeats(newEntity);

            return newEntity.Id;
        }


        public async Task<bool> UpdateAsync(LicenseUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.Where(x => x.Id == request.Id && !x.IsDeleted).Include(x=>x.LicenseSeats).FirstOrDefaultAsync();

            if (entity == null)
                throw new NotFoundException($"License not found");

            await UpdateSeats(entity, request.Seats);

            entity = request.ToMap(entity);
            entity.Available = entity.LicenseSeats.Count(ls => ls.IssuedToUserId == null && ls.IssuedToAssetId == null && !ls.IsDeleted);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }



        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            License entity = await _repository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("License not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<LicenseViewModel> Get(long id, CancellationToken cancellationToken = default)
        {

            var result = await _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Select(x => new LicenseViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductKey = x.ProductKey,
                    Seats = x.Seats,
                    OrderNumber = x.OrderNumber,
                    LicenseToName = x.LicenseToName,
                    LicenseToEmail = x.LicenseToEmail,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    ExpireDate = x.ExpireDate,
                    Note = x.Note,
                    CategoryId = x.CategoryId,
                    ManufacturerId = x.ManufacturerId,
                    IsActive = x.IsActive,
                    SupplierId = x.SupplierId,
                    LocationId = x.LocationId,
                    DepreciationId = x.DepreciationId
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("License not found");

            return result;
        }

        public async Task<LicenseViewModel> GetDetails(long id, CancellationToken cancellationToken = default)
        {

            var result = await _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .Where(x => x.IsActive == true)
                .Include(x => x.Manufacturer)
                .Include(x => x.Supplier)
                .Include(x => x.Location)
                .Include(x => x.Depreciation)
                .Include(x => x.LicenseSeats).ThenInclude(x => x.IssuedToUser)
                .Select(x => new LicenseViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductKey = x.ProductKey,
                    Seats = x.Seats,
                    OrderNumber = x.OrderNumber,
                    LicenseToName = x.LicenseToName,
                    LicenseToEmail = x.LicenseToEmail,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    ExpireDate = x.ExpireDate,
                    Note = x.Note,
                    CategoryId = x.CategoryId,
                    Category = x.Category,
                    ManufacturerId = x.ManufacturerId,
                    Manufacturer = x.Manufacturer,
                    IsActive = x.IsActive,
                    SupplierId = x.SupplierId,
                    Supplier = x.Supplier,
                    LocationId = x.LocationId,
                    DepreciationId = x.DepreciationId,
                    Depreciation = x.Depreciation,
                    SeatList = x.LicenseSeats.Where(ls=>!ls.IsDeleted).ToList()

                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("License not found");

            return result;
        }


        public async Task<PagedCollection<LicenseViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var itemsQuery = _repository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions);

            var items = await itemsQuery
                .ApplyPagination(pagingOptions)
                .Select(x => new LicenseViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ProductKey = x.ProductKey,
                    Seats = x.Seats,
                    Available = (int)x.Available,
                    OrderNumber = x.OrderNumber,
                    LicenseToName = x.LicenseToName,
                    LicenseToEmail = x.LicenseToEmail,
                    PurchaseDate = x.PurchaseDate,
                    PurchaseCost = x.PurchaseCost,
                    ExpireDate = x.ExpireDate,
                    Note = x.Note,
                    CategoryId = x.CategoryId,
                    ManufacturerId = x.ManufacturerId,
                    IsActive = x.IsActive,
                    SupplierId = x.SupplierId,
                    LocationId = x.LocationId,
                    DepreciationId = x.DepreciationId
                })
                .ToListAsync();

            var total = await itemsQuery.Select(x => x.Id).CountAsync();

            var result = new PagedCollection<LicenseViewModel>(items, total, pagingOptions);
            return result;
        }

        public async Task<long> CreateSeats(License license, CancellationToken ct = default)
        {
            List<LicenseSeat> items = new List<LicenseSeat>();
            for (int i = 0; i < license.Seats; i++)
            {
                items.Add(new LicenseSeat
                {
                    Name = "Seat " + i,
                    LicenseId = license.Id
                });
            }
            await _seatRepository.AddRangeAsync(items, ct);
            var result = await _unitOfWork.SaveChangesAsync(ct);
            return result;
        }

        public async Task UpdateSeats(License license, int requestedSeats, CancellationToken ct = default)
        {
            List<LicenseSeat> licenseSeats = license.LicenseSeats.Where(ls =>!ls.IsDeleted).ToList();
            if (licenseSeats.Count < requestedSeats)
            {
                List<LicenseSeat> items = new List<LicenseSeat>();
                for (int i = 1; i <= (requestedSeats - licenseSeats.Count); i++)
                {
                    items.Add(new LicenseSeat
                    {
                        Name = "Seat " + (licenseSeats.Count + i),
                        LicenseId = license.Id
                    });
                }
                await _seatRepository.AddRangeAsync(items, ct);
            }
            else if(licenseSeats.Count > requestedSeats)
            {
                var availableToDelete = licenseSeats.Count(ls => ls.IssuedToUserId == null);
                var requestedToDelete = (licenseSeats.Count - requestedSeats);
                
                if (availableToDelete < requestedToDelete)
                {
                    throw new Exception("This license is currently checked out to a user and cannot be deleted. Please check the license in first, and then try deleting again.");
                }
                else
                {
                    licenseSeats = licenseSeats.OrderByDescending(ls => ls.Id).Take(requestedToDelete).ToList();
                    foreach(LicenseSeat licenseSeat in licenseSeats)
                    {
                        licenseSeat.IsDeleted = true;
                    }
                }
            }
            await _unitOfWork.SaveChangesAsync(ct);
        }

        public async Task<bool> CheckoutAsync(LicenseCheckoutRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.Where(x => x.Id == request.Id && !x.IsDeleted).Include(x => x.LicenseSeats).FirstOrDefaultAsync();

            if (entity == null)
                throw new NotFoundException($"License not found");

            var availableLicenceSeat = entity.LicenseSeats.FirstOrDefault(ls => ls.IssuedToUserId == null && ls.IssuedToAssetId == null && !ls.IsDeleted);
            
            if(availableLicenceSeat != null)
            {
                availableLicenceSeat.IssuedToUserId = request.IssuedToUserId;
                entity.Available = entity.Available - 1;

                //create history
                var newEntity = request.ToMap();
                newEntity.TargetType = AssetType.Users;
                newEntity.ItemType = AssetType.Seats;
                newEntity.ItemId = availableLicenceSeat.Id;
                await _checkoutHistoryRepository.AddAsync(newEntity, cancellationToken);
            }
            else
            {
                throw new NotFoundException($"License Seat not found");
            }
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

    }
}