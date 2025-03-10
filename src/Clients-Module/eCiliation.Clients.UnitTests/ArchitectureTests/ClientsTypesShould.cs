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
    //// Arrange
    //var domainTypes = Types()
    //  .That()
    //  .ResideInNamespace("eCiliation.Clients.*", true)
    //  .As("Clients types");

    //// Act
    //var rule = domainTypes.Should().BeInternal();

    //// Assert
    //rule.Check(Architecture);
  }  
}
// != means: Not accessible/referenceable 
// todo: implement clean architecture rules
// todo: CA rule: domain != infrastructure (data)
// todo: CA rule: domain != use cases (application/service)
// todo: CA rule: domain != endpoints (presentation)
// todo: clients type != any other types (modules)


// Extra lines of code for arrange arch test that don't fit what I'm doing at the moment
// but will keep for possible use later.
// New lines of code start after the .ResideInAnamespace("eCiliation.Clients.*", true) line.
//.And()
//.AreNot([typeof(AssemblyInfo), typeof(PaymentsModuleServiceRegistrar)])
//.And()
//.DoNotResideInNamespace("eShop.Payments.Data.Migrations")
