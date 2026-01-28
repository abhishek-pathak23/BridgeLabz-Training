using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class UserRegistrationTests
{
    private UserRegistration registration;

    [TestInitialize]
    public void Init()
    {
        registration = new UserRegistration();
    }

    [TestMethod]
    public void ValidUserRegistration_DoesNotThrow()
    {
        registration.RegisterUser("Ankit", "ankit@mail.com", "Password1");
        Assert.IsTrue(true);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InvalidUserRegistration_ThrowsException()
    {
        registration.RegisterUser("", "email@mail.com", "pass");
    }
}