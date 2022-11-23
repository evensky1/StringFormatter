namespace StringFormatter.impl.Automaton;

public enum AutomatonState
{
    Init = 0,
    PreFieldName,
    FieldName,
    EndField,
    PreShield,
    Shield,
    Exception
}