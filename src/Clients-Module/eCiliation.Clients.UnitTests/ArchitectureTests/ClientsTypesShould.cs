using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace eCiliation.Clients.UnitTests.ArchitectureTests;
public class ClientsTypesShould
{
  private static readonly Architecture Architecture =
  new ArchLoader()
      .LoadAssemblies(typeof(AssemblyInfo).Assembly)
      .Build();

  [Fact]
  public void BeInternal()
  {
    // Arrange
    var domainTypes = Types()
      .That()
      .ResideInNamespace("eCiliation.Clients.*", true)
      //.And()
      //.AreNot([typeof(AssemblyInfo), typeof(PaymentsModuleServiceRegistrar)])
      //.And()
      //.DoNotResideInNamespace("eShop.Payments.Data.Migrations")
      .As("Clients types");

    // Act
    var rule = domainTypes.Should().BeInternal();

    // Assert
    rule.Check(Architecture);
  }
}
