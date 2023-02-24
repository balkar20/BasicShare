using System.Runtime.CompilerServices;

namespace BaseClientLibrary.Attributes;

public class MethodStatusAttribute: Attribute
{
    public string PreAction;
    public string PostAction;

    public MethodStatusAttribute()
    {
        
    }
}