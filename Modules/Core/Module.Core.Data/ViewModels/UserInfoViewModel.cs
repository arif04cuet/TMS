using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class UserInfoViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<IdNameViewModel> Roles { get; set; }
    }
}
