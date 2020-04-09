using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class Language : BaseEntityWithTypeId<string>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
    }
}
