using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class AssetCategoryViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsRequireUserConfirmation { get; set; }
        public bool IsSendEmailToUser { get; set; }
    }
}
