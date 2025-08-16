using MachOps.Domain.Validations;
using MachOps.Domain.ValueObjects.Machinery;

namespace MachOps.Test.ValueObjects;

[Trait("Category", "ValueObjectTest")]
public sealed class ValueObjectsTest
{
    private const string NameNullOrEmptyMessage = "Name não pode ser nulo nem vazio.";
    private const string MachTypeInvalidMessage = "MachType inválido.";
    private const string StatusInvalidMessage = "Status inválido.";

    [Theory]
    [InlineData("BC-009")]
    [InlineData("EM-072")]
    [InlineData("UC-5567")]
    public void Name_WithValidString_ShouldNotThrowDomainException(string name)
    {
        var ex = Record.Exception(() => new Name(name));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Name_WithEmptyStringOrNull_ShouldThrowDomainException(string name)
    {
        var ex = Assert.Throws<DomainException>(() => new Name(name));
        Assert.NotNull(ex);
        Assert.Equal(NameNullOrEmptyMessage, ex.Message);
    }

    [Theory]
    [InlineData("Description exemple")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Description_WithAnyString_ShouldNotThrowDomainException(string description)
    {
        var ex = Record.Exception(() => new Description(description));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData("Location exemple")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Location_WithAnyString_ShouldNotThrowDomainException(string location)
    {
        var ex = Record.Exception(() => new Location(location));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public void MachType_WithValidEnum_ShouldNotThrowEnumException(int machType)
    {
        var ex = Record.Exception(() => new MachType(machType));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(999)]
    [InlineData(-1)]
    public void MachType_WithInvalidEnum_ShouldThrowEnumException(int machType)
    {
        var ex = Assert.Throws<EnumException>(() => new MachType(machType));
        Assert.NotNull(ex);
        Assert.Equal(MachTypeInvalidMessage, ex.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Status_WithValidEnum_ShouldNotThrowEnumException(int status)
    {
        var ex = Record.Exception(() => new Status(status));
        Assert.Null(ex);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(999)]
    [InlineData(-1)]
    public void Status_WithInvalidEnum_ShouldThrowEnumException(int status)
    {
        var ex = Assert.Throws<EnumException>(() => new Status(status));
        Assert.NotNull(ex);
        Assert.Equal(StatusInvalidMessage, ex.Message);
    }
}