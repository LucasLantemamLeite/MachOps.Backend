using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.UserAccount;

namespace MachOps.Test.ValueObjects;

[Trait("Category", "UserAccountTest")]
public sealed class UserAccountTest
{
    private const string NameNullOrEmptyMessage = "Nome do usuário não pode ser nulo nem vazio.";
    private const string PassowrdNullOrEmptyMessage = "Senha do usuário não pode ser nulo nem vazio.";
    private const string EmailInvalidMessage = "Email inválido.";
    private const string PhoneInvalidMessage = "Phone inválido.";
    private const string RoleInvalidMessage = "Role inválido.";


    [Theory]
    [InlineData("Lucas")]
    [InlineData("Ana")]
    [InlineData("Roberto")]
    public void Name_WithValidString_ShouldNotThrowDomainException(string name)
    {
        var ex = Record.Exception(() => new Name(name));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("     ")]
    [InlineData(null)]
    public void Name_WithEmptyStringOrNull_ShouldThrowDomainException(string name)
    {
        var ex = Assert.Throws<DomainException>(() => new Name(name));
        Assert.NotNull(ex);
        Assert.Equal(NameNullOrEmptyMessage, ex.Message);
    }

    [Theory]
    [InlineData("Lucas1232")]
    [InlineData("Anaçoeq123")]
    [InlineData("Robertozxfgh2e2")]
    public void Password_WithValidString_ShouldNotThrowDomainException(string password)
    {
        var ex = Record.Exception(() => new Password(password));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("     ")]
    [InlineData(null)]
    public void Password_WithEmptyStringOrNull_ShouldThrowDomainException(string password)
    {
        var ex = Assert.Throws<DomainException>(() => new Password(password));
        Assert.NotNull(ex);
        Assert.Equal(PassowrdNullOrEmptyMessage, ex.Message);
    }

    [Theory]
    [InlineData("leontine1181@uorak.com")]
    [InlineData("svyatoslav2837@uorak.com")]
    [InlineData("zeeshan3784@uorak.com")]
    [InlineData("gertie8490@uorak.com.br")]
    public void Email_WithValidString_ShouldNotThrowEmailRegexException(string email)
    {
        var ex = Record.Exception(() => new Email(email));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Email_WithEmptyString_ShouldThrowEmailRegexException(string email)
    {
        var ex = Assert.Throws<EmailRegexException>(() => new Email(email));
        Assert.NotNull(ex);
        Assert.Equal(EmailInvalidMessage, ex.Message);
    }

    [Theory]
    [InlineData("leontine1181")]
    [InlineData("@uorak.com")]
    [InlineData("zeeshan3784@")]
    public void Email_WithInvalidString_ShouldNotThrowEmailRegexException(string email)
    {
        var ex = Assert.Throws<EmailRegexException>(() => new Email(email));
        Assert.NotNull(ex);
        Assert.Equal(EmailInvalidMessage, ex.Message);
    }

    [Theory]
    [InlineData("+55759955246742")]
    [InlineData("+5517983190058")]
    [InlineData("+556596864516")]
    public void Phone_WithValidString_ShouldNotThrowPhoneRegexException(string phone)
    {
        var ex = Record.Exception(() => new Phone(phone));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("     ")]
    public void Phone_WithEmptyString_ShouldThrowPhoneRegexException(string phone)
    {
        var ex = Assert.Throws<PhoneRegexException>(() => new Phone(phone));
        Assert.NotNull(ex);
        Assert.Equal(PhoneInvalidMessage, ex.Message);
    }

    [Fact]
    public void Phone_WithOnlyPlusSymbol_ShouldThrowPhoneRegexException()
    {
        var ex = Assert.Throws<PhoneRegexException>(() => new Phone("+"));
        Assert.NotNull(ex);
        Assert.Equal(PhoneInvalidMessage, ex.Message);
    }

    [Theory]
    [InlineData("+5549994")]
    [InlineData("+554999")]
    [InlineData("+55499")]
    public void Phone_WithLess7Digits_ShouldThrowPhoneRegexException(string phone)
    {
        var ex = Assert.Throws<PhoneRegexException>(() => new Phone(phone));
        Assert.NotNull(ex);
        Assert.Equal(PhoneInvalidMessage, ex.Message);
    }

    [Theory]
    [InlineData("+554999947329623015")]
    [InlineData("+55499946487913563")]
    [InlineData("+5549946545467877")]
    public void Phone_WithMore15Digits_ShouldThrowPhoneRegexException(string phone)
    {
        var ex = Assert.Throws<PhoneRegexException>(() => new Phone(phone));
        Assert.NotNull(ex);
        Assert.Equal(PhoneInvalidMessage, ex.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    [InlineData(7)]
    [InlineData(31)]
    [InlineData(63)]
    public void Role_WithValidInt_ShouldNotThrowEnumFlagsException(int role)
    {
        var ex = Record.Exception(() => new Role(role));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData(64)]
    [InlineData(65)]
    [InlineData(-1)]
    [InlineData(999)]
    public void Role_WithInvalidInt_ShouldThrowEnumFlagsException(int role)
    {
        var ex = Assert.Throws<EnumFlagsException>(() => new Role(role));
        Assert.NotNull(ex);
        Assert.Equal(RoleInvalidMessage, ex.Message);
    }
}
