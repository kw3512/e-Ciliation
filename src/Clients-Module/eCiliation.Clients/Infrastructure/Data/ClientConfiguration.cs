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
      createStamp.Property(x => x.CreatedBy)
      .HasMaxLength(50)
      .HasColumnName("CreatedBy");

      createStamp.Property(x => x.CreatedOn)
      .HasColumnName("CreatedOn");
    });

    builder.ComplexProperty(u => u.UpdateStamp, updateStatmp =>
    {
      updateStatmp.Property(x => x.UpdatedOn)
      .HasColumnName("UpdatedOn");
      updateStatmp.Property(x => x.UpdatedBy)
      .HasMaxLength(50)
      .HasColumnName("UpdatedBy");
    });
  }
}
