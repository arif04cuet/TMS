using System.Collections.Generic;

namespace Module.Core.Data
{

    public class CheckPermissionRequest
    {
        public long? UserId { get; set; }
        public IEnumerable<string> Permissions { get; set; }
    }

}
