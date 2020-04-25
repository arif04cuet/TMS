using System.Collections.Generic;

namespace Module.Core.Data
{
    public class UserUpdateRequest : UserCreateRequest
    {
        public long Id { get; set; }
        public List<long> Permissions { get; set; }
    }

}
