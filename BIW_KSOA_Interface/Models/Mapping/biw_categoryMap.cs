using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class biw_categoryMap : EntityTypeConfiguration<biw_category>
    {
        public biw_categoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.category_no, t.category_name, t.level });

            // Properties
            this.Property(t => t.category_no)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.category_name)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.level)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("biw_category");
            this.Property(t => t.category_no).HasColumnName("category_no");
            this.Property(t => t.category_name).HasColumnName("category_name");
            this.Property(t => t.level).HasColumnName("level");
        }
    }
}
