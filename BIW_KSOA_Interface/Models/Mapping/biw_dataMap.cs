using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class biw_dataMap : EntityTypeConfiguration<biw_data>
    {
        public biw_dataMap()
        {
            // Primary Key
            this.HasKey(t => new { t.spid, t.monthsale, t.zhjj, t.stock, t.drshl });

            // Properties
            this.Property(t => t.spid)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.monthsale)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.zhjj)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.stock)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.drshl)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("biw_data");
            this.Property(t => t.spid).HasColumnName("spid");
            this.Property(t => t.monthsale).HasColumnName("monthsale");
            this.Property(t => t.zhjj).HasColumnName("zhjj");
            this.Property(t => t.stock).HasColumnName("stock");
            this.Property(t => t.drshl).HasColumnName("drshl");
        }
    }
}
