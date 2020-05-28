namespace Project.Hub.Config.Entities.Common
{
    /// <summary>
    /// Represent base configuration that describes generic item.
    /// </summary>
    public class BaseConfig
    {
        /// <summary>
        /// Short name of the item to display.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Explanation of item's purpose or any other additional information about it.
        /// </summary>
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
