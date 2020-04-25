using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Core.Entities
{
    [Table(nameof(UserToken), Schema = SchemaConstants.Core)]
    public class UserToken : IEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public long RefreshTokenId { get; set; }
        public RefreshToken RefreshToken { get; set; }

        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}