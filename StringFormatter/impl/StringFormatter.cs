namespace StringFormatter.impl;

public class StringFormatter : IStringFormatter
{
    public static readonly StringFormatter Shared = new StringFormatter();
    
    public string Format(string template, object target)
    {
        throw new NotImplementedException();
    }
}