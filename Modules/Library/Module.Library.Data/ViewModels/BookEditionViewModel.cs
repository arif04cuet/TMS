using Module.Core.Data;
using Module.Core.Shared;
using Module.Library.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Library.Data
{
    public class BookEditionViewModel : IViewModel
    {
        public long Id { get; set; }
        public IdNameViewModel Book { get; set; }
        public EBookViewModel EBook { get; set; }
        public DateTime PublicationDate { get; set; }
        public int NumberOfPage { get; set; }
        public int NumberOfCopy { get; set; }
        public string Edition { get; set; }

        public static Expression<Func<BookEdition, BookEditionViewModel>> Select(IMediaService mediaService)
        {
            return x => new BookEditionViewModel
            {
                Id = x.Id,
                Edition = x.Edition,
                NumberOfCopy = x.NumberOfCopy,
                NumberOfPage = x.NumberOfPage,
                PublicationDate = x.PublicationDate,
                EBook = x.EBookId != null ? new EBookViewModel
                {
                    Id = x.Id,
                    EBook = x.EBook.MediaId,
                    FileName = x.EBook.Media.FileName,
                    EBook2 = x.EBook.Media2Id,
                    FileName2 = x.EBook.Media2.FileName,
                    IsDownloadable = x.EBook.IsDownloadable
                } : null
            };
        }

    }
}
