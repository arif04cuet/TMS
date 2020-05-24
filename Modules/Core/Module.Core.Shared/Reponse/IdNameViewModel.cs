using Infrastructure.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Core.Shared
{
    public class IdNameViewModel : INameViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static IdNameViewModel Map(IdNameEntity idNameEntity)
        {
            if (idNameEntity != null)
            {
                return new IdNameViewModel
                {
                    Id = idNameEntity.Id,
                    Name = idNameEntity.Name
                };
            }
            return default;
        }

        public static Expression<Func<TEntity, IdNameViewModel>> Select<TEntity>()
            where TEntity : IdNameEntity
        {
            return (TEntity x) => new IdNameViewModel
            {
                Id = x.Id,
                Name = x.Name
            };
        }
    }
}
