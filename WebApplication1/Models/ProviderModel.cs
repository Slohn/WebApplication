using Entities;

namespace UI.Models
{
    public class ProviderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProviderModel() { }
        public ProviderModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Provider ToEntity(ProviderModel obj)
        {
            return obj == null
                ? null
                : new Provider(obj.Id, obj.Name);
        }

        public static ProviderModel FromEntity(Provider obj)
        {
            return obj == null
                ? null
                : new ProviderModel(obj.Id, obj.Name);
        }
    }
}
