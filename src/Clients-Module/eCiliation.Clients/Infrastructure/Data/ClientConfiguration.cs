using eCiliation.Clients.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCiliation.Clients.Infrastructure.Data;

internal class ClientConfiguration : IEntityTypeConfiguration<Client>
{
  public void Configure(EntityTypeBuilder<Client> builder)
  {
    builder.Property(p => p.Id)
      .ValueGeneratedNever();

    builder.ComplexProperty(o => o.CreateStamp, createStamp =>
    {
      createStamp.Property(x => x.CreatedOn);
      createStamp.Property(x => x.CreatedBy)
      .HasMaxLength(50);     
    });

    builder.ComplexProperty(u => u.UpdateStamp, updateStatmp =>
    {
      updateStatmp.Property(x => x.UpdatedOn);      
      updateStatmp.Property(x => x.UpdatedBy)
      .HasMaxLength(50);
    });
  }
}
