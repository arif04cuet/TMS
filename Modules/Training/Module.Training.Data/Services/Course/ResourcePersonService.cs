using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Entities;
using Module.Core.Shared;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class ResourcePersonService : IResourcePersonService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ResourcePerson> _resourcePersonRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ResourcePersonExpertise> _resourcePersonExpertiseRepository;

        public ResourcePersonService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _resourcePersonRepository = _unitOfWork.GetRepository<ResourcePerson>();
            _userRepository = _unitOfWork.GetRepository<User>();
            _resourcePersonExpertiseRepository = _unitOfWork.GetRepository<ResourcePersonExpertise>();
        }

        public async Task<long> CreateAsync(ResourcePersonCreateRequest request, CancellationToken cancellationToken = default)
        {
            ValidateResourcePerson(request.Email, request.Mobile);

            var user = request.MapUser();
            await _userRepository.AddAsync(user);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var person = request.MapResourcePerson();
            person.UserId = user.Id;
            await _resourcePersonRepository.AddAsync(person);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            var expertises = request.Expertises.Select(x => new ResourcePersonExpertise
            {
                ExpertiseId = x,
                ResourcePersonId = person.Id
            });
            await _resourcePersonExpertiseRepository.AddRangeAsync(expertises);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return person.Id;
        }

        public async Task<bool> UpdateAsync(ResourcePersonUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _resourcePersonRepository
                .AsQueryable()
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Resource person not found");

            ValidateResourcePerson(request.Email, request.Mobile, entity.UserId);

            request.MapUser(entity.User);
            request.MapResourcePerson(entity);

            await _resourcePersonExpertiseRepository.UpdateAsync(
                request.Expertises,
                x => x.ResourcePersonId == request.Id,
                x => x.ExpertiseId,
                x => new ResourcePersonExpertise
                {
                    ExpertiseId = x,
                    ResourcePersonId = request.Id
                },
                ids => x => ids.Contains(x.ExpertiseId) && x.ResourcePersonId == request.Id);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _resourcePersonRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Resource person not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<ResourcePersonViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _resourcePersonRepository.GetAsync(x => x.Id == id, ResourcePersonViewModel.Select());

            item.Expertises = await _resourcePersonExpertiseRepository
                .AsReadOnly()
                .Where(x => x.ResourcePersonId == id && !x.IsDeleted)
                .Select(x => new IdNameViewModel { Id = x.ExpertiseId, Name = x.Expertise.Name })
                .ToListAsync();

            return item;
        }

        public async Task<PagedCollection<ResourcePersonViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var result = await _resourcePersonRepository.ListAsync(ResourcePersonViewModel.Select(), pagingOptions, searchOptions, cancellationToken);
            return result;
        }

        private void ValidateResourcePerson(string email, string mobile, long? ignoredUserId = null)
        {
            var isValidMobile = new UniqueMobileValidator(_unitOfWork, ignoredUserId).IsValid(mobile);

            if (!isValidMobile)
                throw new ValidationException("Mobile not available");

            var isValidEmail = new UniqueEmailValidator(_unitOfWork, ignoredUserId).IsValid(email);

            if (!isValidEmail)
                throw new ValidationException("Email not available");
        }

    }
}
