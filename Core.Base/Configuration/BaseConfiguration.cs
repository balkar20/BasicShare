namespace Core.Base.Configuration;

public abstract class BaseConfiguration
{
    private readonly Func<string, string> _getConfigFunc;
    
    protected BaseConfiguration(Func<string, string> getConfigFunc)
    {
        _getConfigFunc = getConfigFunc;
    }

    protected bool GetConfigFuncBool(string name)
    {
        bool defaultResult = false;
        var result = _getConfigFunc(name);
        if (string.IsNullOrWhiteSpace(result))
        {
            return defaultResult;
        }
        
        return Convert.ToBoolean(result);
    }
    
    protected string GetConfigFuncString(string name)
    {
        string defaultResult = String.Empty;
        var result = _getConfigFunc(name);
        if (string.IsNullOrWhiteSpace(result))
        {
            return defaultResult;
        }
        
        return result;
    }
    
    protected int GetConfigFuncInt(string name)
    {
        int defaultResult = 0;
        var result = _getConfigFunc(name);
        if (string.IsNullOrWhiteSpace(result))
        {
            return defaultResult;
        }
        
        return Convert.ToInt32(result);
    }
}