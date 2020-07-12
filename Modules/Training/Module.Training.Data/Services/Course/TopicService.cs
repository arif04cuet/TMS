using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Data;
using Module.Core.Shared;
using Module.Training.Entities;
using Msi.UtilityKit.Pagination;
using Msi.UtilityKit.Search;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Training.Data
{
    public class TopicService : ITopicService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Topic> _topicRepository;
        private readonly IRepository<TopicResourcePerson> _topicResourcePersonRepository;

        public TopicService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _topicRepository = _unitOfWork.GetRepository<Topic>();
            _topicResourcePersonRepository = _unitOfWork.GetRepository<TopicResourcePerson>();
        }

        public async Task<long> CreateAsync(TopicCreateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Map();
            await _topicRepository.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            var resourcePersons = request.ResourcePersons.Select(x => new TopicResourcePerson
            {
                TopicId = entity.Id,
                ResourcePersonId = x
            });
            await _topicResourcePersonRepository.AddRangeAsync(resourcePersons);
            result += await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<bool> UpdateAsync(TopicUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var entity = await _topicRepository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted);

            if (entity == null)
                throw new NotFoundException($"Topic not found");

            request.Map(entity);

            await _topicResourcePersonRepository.UpdateAsync(
                request.ResourcePersons,
                x => x.TopicId == request.Id,
                x => x.ResourcePersonId,
                x => new TopicResourcePerson
                {
                    TopicId = request.Id,
                    ResourcePersonId = x
                },
                ids => x => ids.Contains(x.ResourcePersonId) && x.TopicId == request.Id);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = await _topicRepository.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, true);

            if (entity == null)
                throw new NotFoundException("Topic not found");

            entity.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task<TopicViewModel> Get(long id, CancellationToken cancellationToken = default)
        {
            var item = await _topicRepository
                .AsReadOnly()
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(TopicViewModel.Select())
                .FirstOrDefaultAsync();

            if (item == null)
                throw new NotFoundException("Topic not found");

            item.ResourcePersons = await _topicResourcePersonRepository
                .AsReadOnly()
                .Where(x => x.TopicId == id && !x.IsDeleted)
                .Select(x => new IdNameViewModel
                {
                    Id = x.ResourcePersonId,
                    Name = x.ResourcePerson.User.FullName
                })
                .ToListAsync();

            return item;
        }

        public async Task<PagedCollection<TopicListViewModel>> ListAsync(IPagingOptions pagingOptions, ISearchOptions searchOptions = default, CancellationToken cancellationToken = default)
        {
            var topics = _topicRepository
                .AsReadOnly()
                .Where(x => !x.IsDeleted)
                .ApplySearch(searchOptions)
                .ApplyPagination(pagingOptions);

            var results = topics.Select(x => TopicListViewModel.Map(x));

            var total = await topics.Select(x => x.Id).CountAsync(cancellationToken);
            var items = await results.ToListAsync(cancellationToken);

            var result = new PagedCollection<TopicListViewModel>(items, total, pagingOptions);
            return result;
        }

    }
}
