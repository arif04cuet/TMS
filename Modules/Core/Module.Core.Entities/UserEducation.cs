using Infrastructure.Entities;
using System;

namespace Module.Core.Entities
{
    public class UserEducation : IEntity
    {
        public long Id { get; set; }
        public long UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public DateTime PassingYear { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
    }
}
