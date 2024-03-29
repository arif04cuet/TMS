﻿using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Library.Entities
{
    [Table(nameof(Rack), Schema = SchemaConstants.Library)]
    public class Rack : IdNameEntity
    {
        [Searchable]
        public int FloorNo { get; set; }
        [Searchable]

        public string BuildingName { get; set; }
        [Searchable]
        public long? LibraryId { get; set; }
        [Searchable]
        public Library Library { get; set; }

    }
}
