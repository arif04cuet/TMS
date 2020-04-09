using Infrastructure.Entities;
using System;

namespace Module.Core.Entities
{
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