using Infrastructure.Entities;
using System;

namespace Module.Core.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}