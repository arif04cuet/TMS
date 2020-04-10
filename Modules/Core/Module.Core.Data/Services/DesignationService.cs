using Infrastructure;
using Infrastructure.Data;
using Module.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Core.Data
{
    public class DesignationService : IdNameServiceBase<Designation>, IDesignationService
    {
        public DesignationService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<long> CreateAsync(DesignationCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newItem = new Designation
            {
                Name = request.Name,
            };

            await _repository.AddAsync(newItem, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newItem.Id;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var item = await _repository.FirstOrDefaultAsync(x => x.Id == id, true);

            if (item == null)
                throw new NotFoundException("Designation not found");

            _repository.Remove(item);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(DesignationUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var item = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (item == null)
                throw new NotFoundException($"Designation not found");

            item.Name = request.Name;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

    }
}
