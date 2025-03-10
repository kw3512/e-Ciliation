using eCiliation.Clients.Domain;
using FluentAssertions;

namespace eCiliation.Clients.UnitTests;

public class ClientsShould
{
  private static string _userId = "tUser";
  private static readonly Guid _clientId = Guid.NewGuid();
  private static string _clientName = "Client Name";

  private readonly Client _sut = new(_clientId, _clientName, _userId);

  [Fact]
  public void Be_In_ValidState_AfterInitialization()
  {
    // Assert
    _sut.Name.Should().BeEquivalentTo(_clientName);
    _sut.ClientId.Should().Be(_clientId);
    _sut.CreateStamp.CreatedBy.Should().BeEquivalentTo(_userId);
    _sut.IsActive.Should().BeTrue();
    _sut.IsActive.Should().BeTrue();
    _sut.UpdateStamp.Should().BeNull();
    _sut.Description.Should().BeEquivalentTo(_sut.Description);  
  }

  // todo: Test Deactivate()
  // todo: Test SetUpdateStamp()
  // todo: Test expection throw for invalid - client id
  // todo: Test expection throw for invalid - client name
  // todo: Test expection throw for invalid - description
  // todo: Test expection throw for invalid - createStamp user id
}
