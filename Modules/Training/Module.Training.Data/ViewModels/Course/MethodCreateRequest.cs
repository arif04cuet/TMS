using Module.Training.Entities;

namespace Module.Training.Data
{
    public class MethodCreateRequest
    {
        public string Name { get; set; }

        public Method Map(Method method = null)
        {
            var entity = method ?? new Method();
            entity.Name = Name;
            return entity;
        }
    }
}
