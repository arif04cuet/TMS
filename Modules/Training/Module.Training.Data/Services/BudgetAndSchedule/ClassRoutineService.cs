using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class ClassRoutineService : IClassRoutineService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ClassRoutine> _classRoutineRepository;
        private readonly IRepository<ClassRoutineModule> _classRoutineModuleRepository;
        private readonly IRepository<ModuleRoutine> _moduleRoutineRepository;
        private readonly IRepository<RoutinePeriod> _routinePeriodRepository;

        public ClassRoutineService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _classRoutineRepository = _unitOfWork.GetRepository<ClassRoutine>();
            _classRoutineModuleRepository = _unitOfWork.GetRepository<ClassRoutineModule>();
            _moduleRoutineRepository = _unitOfWork.GetRepository<ModuleRoutine>();
            _routinePeriodRepository = _unitOfWork.GetRepository<RoutinePeriod>();
        }

        public async Task<long> CreateAsync(ClassRoutineCreateRequest request, CancellationToken cancellationToken = default)
        {

            // check if multiple class routine
            var classRoutineExist = await _classRoutineRepository
                .Where(x => x.BatchScheduleId == request.BatchSchedule && !x.IsDeleted)
                .Select(x => x.Id)
                .CountAsync() > 0;

            if (classRoutineExist)
                throw new ValidationException("Already class routine exists");

            var entity = request.Map();
            await _classRoutineRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            // module routines
            foreach (var module in request.Modules)
            {
                var newModule = module.Map();
                newModule.ClassRoutineId = entity.Id;
                await _classRoutineModuleRepository.AddAsync(newModule, cancellationToken);
                result += await _unitOfWork.SaveChangesAsync(cancellationToken);

                // routines
                foreach (var routine in module.Routines)
                {
                    var newRoutine = routine.Map();
                    newRoutine.ModuleId = newModule.Id;
                    await _moduleRoutineRepository.AddAsync(newRoutine, cancellationToken);
                    result += await _unitOfWork.SaveChangesAsync(cancellationToken);

                    // periods
                    await AddRoutinePeriods(newRoutine.Id, routine.Periods);
                    result += await _unitOfWork.SaveChangesAsync(cancellationToken);
                }

            }
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(ClassRoutineUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _classRoutineRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Class routine not found");

            var result = 0;

            // routine modules
            foreach (var module in request.Modules)
            {
                if (module.Id.HasValue)
                {
                    // update routine module
                    var dbModule = await _classRoutineModuleRepository
                        .FirstOrDefaultAsync(x => x.Id == module.Id.Value && x.ClassRoutineId == request.Id && !x.IsDeleted);

                    if (dbModule == null)
                        throw new ValidationException("Class routine module not found");

                    module.Map(dbModule);

                    // delete module routines
                    // if add new module routines ignore them from deleting
                    var requestModuleRoutineIds = module.Routines
                        .Where(x => x.Id.HasValue)
                        .Select(x => x.Id.Value);

                    var moduleRoutineToBeDeleted = await _moduleRoutineRepository
                        .Where(x => x.ModuleId == module.Id.Value && !requestModuleRoutineIds.Contains(x.Id) && !x.IsDeleted)
                        .ToListAsync();
                    _moduleRoutineRepository.RemoveRange(moduleRoutineToBeDeleted);

                    foreach (var routine in module.Routines)
                    {
                        if (routine.Id.HasValue)
                        {
                            // update module routine
                            var dbModuleRoutine = await _moduleRoutineRepository
                                .FirstOrDefaultAsync(x => x.Id == routine.Id && x.ModuleId == module.Id && !x.IsDeleted);

                            if (dbModuleRoutine == null)
                                throw new ValidationException("Class module routine not found");

                            routine.Map(dbModuleRoutine);

                            // delete periods
                            var requestPeriodIds = routine.Periods
                                .Where(x => x.Id.HasValue)
                                .Select(x => x.Id.Value);

                            var periodToBeDeleted = await _routinePeriodRepository
                                .Where(x => x.RoutineId == routine.Id.Value && !requestPeriodIds.Contains(x.Id) && !x.IsDeleted)
                                .ToListAsync();
                            _routinePeriodRepository.RemoveRange(periodToBeDeleted);

                            foreach (var period in routine.Periods)
                            {
                                if (period.Id.HasValue)
                                {
                                    // update period
                                    var dbPeriod = await _routinePeriodRepository
                                        .FirstOrDefaultAsync(x => x.Id == period.Id && x.RoutineId == routine.Id && !x.IsDeleted);

                                    if (dbPeriod == null)
                                        throw new ValidationException("Class module routine period not found");

                                    period.Map(dbPeriod);
                                }
                                else
                                {
                                    // new period
                                    var newPeriod = period.Map();
                                    newPeriod.RoutineId = routine.Id.Value;
                                    await _routinePeriodRepository.AddAsync(newPeriod);
                                    result += await _unitOfWork.SaveChangesAsync();
                                }
                            }

                        }
                        else
                        {
                            // new module routine
                            var newModuleRoutine = routine.Map();
                            newModuleRoutine.ModuleId = module.Id.Value;
                            await _moduleRoutineRepository.AddAsync(newModuleRoutine);
                            result += await _unitOfWork.SaveChangesAsync();

                            // periods
                            await AddRoutinePeriods(newModuleRoutine.Id, routine.Periods);
                            result += await _unitOfWork.SaveChangesAsync(cancellationToken);
                        }
                    }

                }
                else
                {
                    // new class routine module
                    var newRoutineModule = new ClassRoutineModule();
                    await _classRoutineModuleRepository.AddAsync(newRoutineModule);
                    result += await _unitOfWork.SaveChangesAsync();

                    // module routines
                    foreach (var routine in module.Routines)
                    {
                        var newRoutine = routine.Map();
                        newRoutine.ModuleId = newRoutineModule.Id;
                        await _moduleRoutineRepository.AddAsync(newRoutine, cancellationToken);
                        result += await _unitOfWork.SaveChangesAsync(cancellationToken);

                        // periods
                        await AddRoutinePeriods(newRoutine.Id, routine.Periods);
                        result += await _unitOfWork.SaveChangesAsync(cancellationToken);
                    }
                }
            }

            // delete class routine modules
            //var requestRoutineModuleIds = request.Modules
            //    .Where(x => x.Id.HasValue)
            //    .Select(x => x.Id.Value);

            //var routineModuleToBeDeleted = await _classRoutineModuleRepository
            //    .Where(x => x.ClassRoutineId == request.Id && !requestRoutineModuleIds.Contains(x.Id) && !x.IsDeleted)
            //    .ToListAsync();
            //_classRoutineModuleRepository.RemoveRange(routineModuleToBeDeleted);

            result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _classRoutineRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Class routine not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ClassRoutineViewModel> Get(long classRoutineId, CancellationToken cancellationToken = default)
        {
            var item = await _classRoutineRepository.GetAsync(x => x.Id == classRoutineId, ClassRoutineViewModel.Select(), cancellationToken);
            return item;
        }

        public async Task<PagedCollection<ClassRoutineViewModel>> ListAsync(long batchScheduleId, IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _classRoutineRepository.ListAsync(x => x.BatchScheduleId == batchScheduleId, ClassRoutineViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        private Task AddRoutinePeriods(long moduleRoutineId, IEnumerable<RoutinePeriodRequest> periods)
        {
            // periods
            var newPeriods = periods.Select(x =>
            {
                var newPeriod = x.Map();
                newPeriod.RoutineId = moduleRoutineId;
                return newPeriod;
            });
            return _routinePeriodRepository.AddRangeAsync(newPeriods);
        }

    }
}
