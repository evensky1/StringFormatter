using StringFormatter.impl;
using StringFormatter.impl.Automaton;

namespace StringFormatter.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var fa = new FiniteAutomaton();
        var temp = fa.ParseString("Привет,{{ }}{FirstName} {LastName}!");
        foreach (var token in temp) Console.WriteLine($"Type: {token.Type} value: {token.Value}");
        
        Assert.That(true, Is.True);
    }
}