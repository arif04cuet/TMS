using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Training.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class TrainingService : ITrainingService
    {

        private readonly IUnitOfWork _unitOfWork;

        public TrainingService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TrainingDashboardViewModel> GetDashboard(CancellationToken cancellationToken = default)
        {
            TrainingDashboardViewModel model = new TrainingDashboardViewModel();
            var now = DateTime.UtcNow.Date;

            model.RunningBatches = await _unitOfWork.GetRepository<BatchSchedule>().Where(x => now >= x.StartDate.Date && now <= x.EndDate.Date && !x.IsDeleted).LongCountAsync();

            model.RunningCourses = await _unitOfWork.GetRepository<BatchSchedule>().Where(x => now >= x.StartDate.Date && now <= x.EndDate.Date && !x.IsDeleted).LongCountAsync();

            model.TodaysClasses = await _unitOfWork.GetRepository<RoutinePeriod>().Where(x => x.Routine.TrainingDate.Date == DateTime.UtcNow.Date && !x.IsDeleted).CountAsync();

            model.TodaysExams = await _unitOfWork.GetRepository<Exam>().Where(x => x.ExamDate.Date == DateTime.UtcNow && !x.IsDeleted).CountAsync();

            model.TodaysResourcesPersons = await _unitOfWork.GetRepository<RoutinePeriod>().Where(x => x.Routine.TrainingDate.Date == DateTime.UtcNow.Date && !x.IsDeleted).Select(x => x.ResourcePersonId).Distinct().CountAsync();

            model.TotalParticipants = await _unitOfWork.GetRepository<BatchScheduleAllocation>().Where(x => x.Status == BatchScheduleAllocationStatus.Approved && !x.IsDeleted).LongCountAsync();

            return model;
        }
    }
}
