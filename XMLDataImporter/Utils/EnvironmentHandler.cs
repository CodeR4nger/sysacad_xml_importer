
namespace XMLDataImporter.Utils;

public interface IEnvironmentHandler
{
    void Load();
    string? Get(string key, string? defaultValue = null);
}

public class EnvironmentHandler : IEnvironmentHandler
{
    private bool _isLoaded = false;

    public void Load()
    {
        if (!_isLoaded)
        {
            DotNetEnv.Env.Load();
            _isLoaded = true;
        }
    }

    public string? Get(string key, string? defaultValue = null)
    {
        var envValue = DotNetEnv.Env.GetString(key);
        return string.IsNullOrEmpty(envValue) ? defaultValue : envValue;
    }
}