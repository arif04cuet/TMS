using Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public interface ITrainingService : IScopedService
    {

        Task<TrainingDashboardViewModel> GetDashboard(CancellationToken cancellationToken = default);
    }
}
