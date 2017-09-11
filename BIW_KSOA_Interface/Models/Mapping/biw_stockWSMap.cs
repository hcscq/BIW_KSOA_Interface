using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class biw_stockWSMap : EntityTypeConfiguration<biw_stockWS>
    {
        public biw_stockWSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.goods_Id, t.month_Sales, t.goods_No, t.stock_Amount });

            // Properties
            this.Property(t => t.goods_Id)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.month_Sales)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.goods_No)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.stock_Amount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("biw_stockWS");
            this.Property(t => t.goods_Id).HasColumnName("goods_Id");
            this.Property(t => t.month_Sales).HasColumnName("month_Sales");
            this.Property(t => t.goods_No).HasColumnName("goods_No");
            this.Property(t => t.stock_Amount).HasColumnName("stock_Amount");
        }
    }
}
