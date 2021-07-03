using ffrs.mvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ffrs.mvc.Data.Configurations
{
    public class ContactoConfiguration : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("PRIMARY");
            
            builder.Property(x => x.Id)
                .HasColumnType("varchar(255)");
            
            builder.Property(x => x.Nombres)
                .HasColumnType("varchar(50)");
            
            builder.Property(x => x.Apellidos)
                .HasColumnType("varchar(50)");
            
            builder.Property(x => x.Cedula)
                .HasColumnType("varchar(20)");
            
            builder.Property(x => x.FechaNacimiento)
                .HasColumnType("datetime");
            
            builder.Property(x => x.Telefono)
                .HasColumnType("varchar(20)");
            
            builder.Property(x => x.Direccion)
                .HasColumnType("varchar(300)");
            
        }
    }
}