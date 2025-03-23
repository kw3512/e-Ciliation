using eCiliation.Clients.Domain;
using eCiliation.SharedKernel;
using FluentAssertions;

namespace eCiliation.Clients.UnitTests;

public class ClientsShould
{
    private static string _userId = "tUser";
    private static readonly Guid _id = Guid.NewGuid();
    private static string _clientName = "Client Name";
    private static string _description = "Client Description";

  private readonly Client _sut = new(_clientName, _description, _userId)
  {
    CreateStamp = new CreateStamp(_userId)
  };

  [Fact]
  public void Be_In_ValidState_AfterInitialization()
  {
    // Arrange
    TimeSpan createdOnTimeSpan = new TimeSpan(0, 0, 30);
    _sut.SetUpdateStamp();

    // Assert
    _sut.Name.Should().BeEquivalentTo(_clientName);
    _sut.Id.Should().NotBeEmpty();
    _sut.CreateStamp.CreatedBy.Should().BeEquivalentTo(_userId);
    _sut.CreateStamp.CreatedOn.Should().BeCloseTo(DateTime.Now, createdOnTimeSpan);
    _sut.IsActive.Should().BeTrue();
    _sut.Description.Should().BeEquivalentTo(_description);
  }

  [Fact]
  public void Deactivate_Client()
  {
    // Act
    _sut.Deactivate();

    // Assert
    _sut.IsActive.Should().BeFalse();
  }

  [Fact]
  public void Set_UpdateStamp()
  {
    // Act
    _sut.SetUpdateStamp();

    // Assert
    _sut.UpdateStamp.Should().NotBeNull();
    _sut.UpdateStamp!.UpdatedBy.Should().BeEquivalentTo(_userId);
    _sut.UpdateStamp.UpdatedOn.Should().BeCloseTo(DateTime.Now, new TimeSpan(0, 0, 30));
  }

  [Fact]
  public void Throw_Exception_For_Invalid_ClientName()
  {
    // Act
    Action act = () => new Client("", _description, _userId)
    { 
      CreateStamp = new CreateStamp(_userId)
    };

    // Assert
    act.Should().Throw<ArgumentException>();
  }

  [Theory]
  [InlineData("Client Name", "", "testUser")]
  [InlineData("Client Name", "d", "testUser")]
  [InlineData("Client Name", 
    """
    abcdefghijklmnopqrstuvwxyz
    abcdefghijklmnopqrstuvwxyz
    abcdefghijklmnopqrstuvwxyz
    abcdefghijklmnopqrstuvwxyz
    """
    ,"testUser")]
  public void Throw_Exception_For_Invalid_Description(string name, string desc, string userId)
  {
    // Act
    Action act = () => new Client(name, desc, userId)
    {
      CreateStamp = new CreateStamp(userId)
    }; ;

    // Assert
    act.Should().Throw<ArgumentException>();
  }

  [Fact]
  public void Throw_Exception_For_Invalid_UserId()
  {
    // Act
    Action act = () => new Client(_clientName, _description, "")
    {
      CreateStamp = new CreateStamp("")
    }; ;

    // Assert
    act.Should().Throw<ArgumentException>();
  }
}
