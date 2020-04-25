using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Entities;
using System.Threading;
using System.Threading.Tasks;

using static Module.Core.Shared.MessageConstants;

namespace Module.Core.Shared
{
    public class NameCrudService<T> : NameService<T>, INameCrudService<T> where T : class, IIdNameEntity, new()
    {

        public NameCrudService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public virtual async Task<long> CreateAsync(INameCreateRequest request, CancellationToken cancellationToken = default)
        {
            var newItem = new T
            {
                Name = request.Name,
            };

            await _repository.AddAsync(newItem, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newItem.Id;
        }

        public virtual async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var item = await _repository.FirstOrDefaultAsync(x => x.Id == id, true);

            if (item == null)
                throw new NotFoundException(ITEM_NOT_FOUND);

            _repository.Remove(item);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public virtual async Task<bool> UpdateAsync(INameUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var item = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (item == null)
                throw new NotFoundException(ITEM_NOT_FOUND);

            item.Name = request.Name;

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

    }
}
