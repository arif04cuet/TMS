using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Core.Data
{
    public class RoleUpdateRequest : NameUpdateRequest
    {
        public List<long> Permissions { get; set; }
    }

}
