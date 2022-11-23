using StringFormatter.impl.Exception;

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
    public void String_Formatter_Default_Scenario()
    {
        var user = new User("Олег", "Броварской");
        var temp = impl.StringFormatter.Shared.Format("Привет,{{ }}{FirstName} {LastName}!", user);
        Assert.That(temp, Is.EqualTo("Привет,{ }Олег Броварской!"));
    }

    [Test]
    public void String_Formatter_Greet_Scenario()
    {
        var user = new User("Олег", "Броварской");
        Assert.That(user.GetGreeting(), Is.EqualTo("Привет, Олег Броварской!"));
    }
    
    [Test]
    public void String_Formatter_Invalid_String_Exception()
    {
        var user = new User("Олег", "Броварской");
        var temp = impl.StringFormatter.Shared.Format("Привет,{{ }}{FirstName} {LastName}!{", user);
        Assert.Throws<InvalidStringException>(() => 
            impl.StringFormatter.Shared.Format("Привет,{{ }}{FirstName} {LastName}!{", user));
    }
    
    [Test]
    public void String_Formatter_Empty_String()
    {
        var user = new User("Олег", "Броварской");
        var temp = impl.StringFormatter.Shared.Format("", user);
        Assert.That(temp, Is.EqualTo(""));
    }
}
