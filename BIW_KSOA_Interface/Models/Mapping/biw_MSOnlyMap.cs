using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class biw_MSOnlyMap : EntityTypeConfiguration<biw_MSOnly>
    {
        public biw_MSOnlyMap()
        {
            // Primary Key
            this.HasKey(t => new { t.spid, t.shl, t.spbh });

            // Properties
            this.Property(t => t.spid)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.shl)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.spbh)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("biw_MSOnly");
            this.Property(t => t.spid).HasColumnName("spid");
            this.Property(t => t.shl).HasColumnName("shl");
            this.Property(t => t.spbh).HasColumnName("spbh");
        }
    }
}
