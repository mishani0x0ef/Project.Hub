namespace Project.Hub.Config.Interfaces
{
    public interface IOptionsProvider
    {
        string ConfigPath { get; }
        string LogsPath { get; }
        string PowerShellPath { get; }
    }
}
