using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(RefreshToken), Schema = SchemaConstants.Core)]
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}