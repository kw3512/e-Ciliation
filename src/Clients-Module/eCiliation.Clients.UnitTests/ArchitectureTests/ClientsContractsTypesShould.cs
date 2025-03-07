using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace eCiliation.Clients.UnitTests.ArchitectureTests;
public class ClientsContractsTypesShould
{
  private static readonly Architecture Architecture =
  new ArchLoader()
      .LoadAssemblies(typeof(Contracts.AssemblyInfo).Assembly)
      .Build();

  [Fact]
  public void BeInternal()
  {
    var domainTypes = Types()
      .That()
      .ResideInAssembly("eCiliation.Clients.Contracts*", true)
      .As("Clients Contracts types");

    var rule = domainTypes.Should().BeInternal();

    rule.Check(Architecture);
  }
}
