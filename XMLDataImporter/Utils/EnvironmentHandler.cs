
namespace XMLDataImporter.Utils;

public interface IEnvironmentHandler
{
    void Load();
    string Get(string key);
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

    public string Get(string key)
    {
        var envValue = DotNetEnv.Env.GetString(key);
        if (string.IsNullOrEmpty(envValue))
            throw new InvalidOperationException($"Environment variable '{key}' is not set.");
        return envValue;
    }
}