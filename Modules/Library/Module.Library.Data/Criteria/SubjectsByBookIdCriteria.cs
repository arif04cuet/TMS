using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Module.Core.Shared;
using Module.Library.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Library.Data
{
    public class SubjectsByBookIdCriteria : ICriteria<BookSubject, ICollection<IdNameViewModel>>
    {
        private readonly long _bookId;

        public SubjectsByBookIdCriteria(long bookId)
        {
            _bookId = bookId;
        }

        public async Task<ICollection<IdNameViewModel>> MatchAsync(IQueryable<BookSubject> query, bool readOnly = false)
        {
            var items = await query
                .AsNoTracking()
                .Where(x => x.BookId == _bookId && !x.IsDeleted)
                .Select(x => IdNameViewModel.Map(x.Subject))
                .ToListAsync();
            return items;
        }
    }
}
