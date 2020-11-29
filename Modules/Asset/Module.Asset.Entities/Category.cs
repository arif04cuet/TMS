using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Module.Asset.Entities
{
    [Table(nameof(Category), Schema = SchemaConstants.Asset)]
    [CheckUnique]
    public class Category : BaseEntity
    {
        [Searchable]
        [UniqueField]
        public string Name { get; set; }

        public string EULA { get; set; }
        public bool IsRequireUserConfirmation { get; set; }
        public bool IsSendEmail { get; set; }

        public long? MediaId { get; set; }
        public Media Media { get; set; }

        [Searchable]
        public long? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        [Searchable]
        public virtual Category Parent { get; set; }
        public ICollection<Category> Children { get; private set; }

        public Category()
        {
            Children = new List<Category>();
        }

        public Category(long id, string name, bool active = true)
        {
            Id = id;
            Name = name;
            IsActive = active;
        }
    }
}