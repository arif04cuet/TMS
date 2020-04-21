using Module.Asset.Entities;

namespace Module.Asset.Data
{
    public class CategoryResource
    {
        public string Name { get; set; }
        public MasterCategory Type { get; set; }
        public string Eula { get; set; }
        public bool IsRequireUserConfirmation { get; set; }
        public bool IsSendEmail { get; set; }
        public bool IsActive { get; set; }

    }
}