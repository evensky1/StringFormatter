using System.Text;
using StringFormatter.impl.Automaton;

namespace StringFormatter.impl;

public class StringFormatter : IStringFormatter
{
    public static readonly StringFormatter Shared = new ();
    private readonly FiniteAutomaton _parser = new ();
    public string Format(string template, object target)
    {
        var tokens = _parser.ParseString(template);
        return CreateString(tokens, target);
    }

    private string CreateString(List<Token> tokens, object target)
    {
        var str = new StringBuilder();
        tokens.ForEach(token => str.Append(ParseToken(token, target)));
        return str.ToString();
    }

    private string ParseToken(Token token, object target)
    {
        return token.Type switch
        {
            TokenType.String => token.Value,
            TokenType.Substitution => GetStringFieldValue(token.Value, target),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private string GetStringFieldValue(string fieldName, object target)
    {
        var type = target.GetType();
        var field = type.GetProperty(fieldName);
        var value = field?.GetValue(target);
        return value.ToString();
    }
}