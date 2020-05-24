using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class MethodViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static MethodViewModel Map(Method method)
        {
            return new MethodViewModel
            {
                Id = method.Id,
                Name = method.Name
            };
        }
    }
}
