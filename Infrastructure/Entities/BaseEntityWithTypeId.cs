﻿using System;
using Msi.UtilityKit.Search;

namespace Infrastructure.Entities
{
    [IgnoredEntity]
    public class BaseEntityWithTypeId<TKey> : IEntity
    {
        [Searchable]
        public TKey Id { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        [Searchable]
        public bool IsActive { get; set; } = true;
        public long Version { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
