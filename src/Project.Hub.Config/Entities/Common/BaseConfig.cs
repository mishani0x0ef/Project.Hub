namespace Project.Hub.Config.Entities.Common
{
    public class BaseConfig
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public BaseConfig()
        {
        }

        public BaseConfig(string name, string description = null)
        {
            Name = name;
            Description = description;
        }
    }
}
