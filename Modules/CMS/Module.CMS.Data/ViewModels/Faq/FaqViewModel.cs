using Module.Core.Shared;
using Module.CMS.Entities;
using System.IO;
using System.Linq.Expressions;
using System;
using Module.Core.Entities;

namespace Module.CMS.Data
{
    public class FaqViewModel : IViewModel
    {

        public long Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }


        public static Expression<Func<Faq, FaqViewModel>> Select()
        {
            return x => new FaqViewModel
            {
                Id = x.Id,
                Question = x.Question,
                Answer = x.Answer,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt.ToString(),
                UpdatedAt = x.UpdatedAt.ToString(),

            };
        }

    }
}
