using StringFormatter.impl;
using StringFormatter.impl.Automaton;

namespace StringFormatter.Tests;

public class Tests
{
    private class User
    {
        public string FirstName { get; }
        public string LastName { get; }
    
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetGreeting()
        {
            return impl.StringFormatter.Shared.Format(
                "Привет, {FirstName} {LastName}!", this);
        }
    }
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var user = new User("Олег", "Броварской");
        var temp = impl.StringFormatter.Shared.Format("Привет,{{ }}{FirstName} {LastName}!", user);
        Assert.That(temp, Is.EqualTo("Привет,{ }Олег Броварской!"));
    }
}
