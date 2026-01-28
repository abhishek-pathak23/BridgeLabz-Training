using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PasswordValidatorTests
{
    private PasswordValidator validator;

    [TestInitialize]
    public void Setup()
    {
        validator = new PasswordValidator();
    }

    [TestMethod]
    public void ValidPassword_ReturnsTrue()
    {
        Assert.IsTrue(validator.IsValid("Secure123"));
    }

    [TestMethod]
    public void PasswordWithoutUppercase_ReturnsFalse()
    {
        Assert.IsFalse(validator.IsValid("secure123"));
    }

    [TestMethod]
    public void PasswordWithoutDigit_ReturnsFalse()
    {
        Assert.IsFalse(validator.IsValid("SecurePass"));
    }

    [TestMethod]
    public void ShortPassword_ReturnsFalse()
    {
        Assert.IsFalse(validator.IsValid("Ab1"));
    }
}