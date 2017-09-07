using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class biw_porders_dMap : EntityTypeConfiguration<biw_porders_d>
    {
        public biw_porders_dMap()
        {
            // Primary Key
            this.HasKey(t => new { t.poNo, t.did });

            // Properties
            this.Property(t => t.poNo)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.did)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.spid)
                .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("biw_porders_d");
            this.Property(t => t.poNo).HasColumnName("poNo");
            this.Property(t => t.did).HasColumnName("did");
            this.Property(t => t.spid).HasColumnName("spid");
            this.Property(t => t.goodsPrice).HasColumnName("goodsPrice");
            this.Property(t => t.goodsQty).HasColumnName("goodsQty");
            this.Property(t => t.goodsAmount).HasColumnName("goodsAmount");
            this.Property(t => t.taxRate).HasColumnName("taxRate");
            this.Property(t => t.withtaxPrice).HasColumnName("withtaxPrice");
            this.Property(t => t.withtaxAmount).HasColumnName("withtaxAmount");
            this.Property(t => t.taxAmount).HasColumnName("taxAmount");
            this.Property(t => t.isGift).HasColumnName("isGift");
        }
    }
}
