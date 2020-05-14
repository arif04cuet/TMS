namespace Module.Asset.Data
{
    public class CategoryResource
    {
        public string Name { get; set; }
        public string Eula { get; set; }
        public bool IsRequireUserConfirmation { get; set; }
        public bool IsSendEmail { get; set; }
        public bool IsActive { get; set; }
        public long? ParentId { get; set; }

    }
}