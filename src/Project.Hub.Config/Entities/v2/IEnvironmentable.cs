namespace Project.Hub.Config.Entities.v2
{
    /// <summary>
    /// Define that implementer describe a specific environment.
    /// </summary>
    public interface IEnvironmentable
    {
        /// <summary>
        /// Environment name that is described.
        /// </summary>
        string Environment { get; set; }
    }
}
