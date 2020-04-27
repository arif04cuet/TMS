using Infrastructure.Entities;

namespace Module.Core.Shared
{
    public class IdNameViewModel : INameViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static IdNameViewModel Map(IdNameEntity idNameEntity)
        {
            if (idNameEntity != null)
            {
                return new IdNameViewModel
                {
                    Id = idNameEntity.Id,
                    Name = idNameEntity.Name
                };
            }
            return default;
        }
    }
}
