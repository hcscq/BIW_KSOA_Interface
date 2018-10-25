using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class biw_priceOnlyMap : EntityTypeConfiguration<biw_priceOnly>
    {
        public biw_priceOnlyMap()
        {
            // Primary Key
            this.HasKey(t => new { t.goods_id, t.goods_no });

            // Properties
            this.Property(t => t.goods_id)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.goods_no)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.mainSupplier)
                .IsFixedLength()
                .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("biw_priceOnly");
            this.Property(t => t.goods_id).HasColumnName("goods_id");
            this.Property(t => t.goods_no).HasColumnName("goods_no");
            this.Property(t => t.retailPrice).HasColumnName("retailPrice");
            this.Property(t => t.lastPPrice).HasColumnName("lastPPrice");
            this.Property(t => t.mainSupplier).HasColumnName("mainSupplier");
            this.Property(t => t.memberPrice).HasColumnName("memberPrice");
        }
    }
}
