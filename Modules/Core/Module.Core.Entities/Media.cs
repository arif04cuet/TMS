using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Media : BaseEntity
    {
        public string Title { get; set; }
        public long Size { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public bool IsInUse { get; set; }
    }
}
