using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class Biw_ReturnPoDMap : EntityTypeConfiguration<Biw_ReturnPoD>
    {
        public Biw_ReturnPoDMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ReturnPoNo, t.GoodsNo, t.Lot, t.Quantity, t.Price, t.TaxPrice, t.TaxRate, t.QualityDesc, t.GoodsAllocation, t.InnerId });

            // Properties
            this.Property(t => t.ReturnPoNo)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.GoodsNo)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Lot)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Quantity)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TaxRate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IsGift)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.QualityDesc)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ExpireDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GoodsAllocation)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.InnerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Biw_ReturnPoD");
            this.Property(t => t.ReturnPoNo).HasColumnName("ReturnPoNo");
            this.Property(t => t.GoodsNo).HasColumnName("GoodsNo");
            this.Property(t => t.Lot).HasColumnName("Lot");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.TaxPrice).HasColumnName("TaxPrice");
            this.Property(t => t.TaxRate).HasColumnName("TaxRate");
            this.Property(t => t.IsGift).HasColumnName("IsGift");
            this.Property(t => t.QualityDesc).HasColumnName("QualityDesc");
            this.Property(t => t.ExpireDate).HasColumnName("ExpireDate");
            this.Property(t => t.GoodsAllocation).HasColumnName("GoodsAllocation");
            this.Property(t => t.InnerId).HasColumnName("InnerId");
        }
    }
}
