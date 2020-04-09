using System;

namespace Module.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RequirePermissionAttribute : Attribute
    {

        public long[] _permissions;

        public RequirePermissionAttribute(params long[] permissions)
        {
            _permissions = permissions;
        }

    }
}
