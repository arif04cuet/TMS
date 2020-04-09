using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Media : BaseEntity
    {
        public string Title { get; set; }
        public long Size { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }
    }
}
