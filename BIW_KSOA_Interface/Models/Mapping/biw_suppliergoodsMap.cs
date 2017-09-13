using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class biw_suppliergoodsMap : EntityTypeConfiguration<biw_suppliergoods>
    {
        public biw_suppliergoodsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.storageQty, t.storageQtyZc, t.storageQtyDs, t.storageQtyMd, t.monthlySalesYd, t.stock2useRatio, t.stock2useRatioFilled, t.goodsPrice, t.withtaxPrice, t.lastPrice, t.settlement, t.sfzgys, t.thhbj });

            // Properties
            this.Property(t => t.jyzt)
                .HasMaxLength(10);

            this.Property(t => t.spx)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.licenseNo)
                .HasMaxLength(200);

            this.Property(t => t.spid)
                .HasMaxLength(11);

            this.Property(t => t.goodsNo)
                .HasMaxLength(15);

            this.Property(t => t.commonName)
                .HasMaxLength(150);

            this.Property(t => t.proAddr)
                .HasMaxLength(60);

            this.Property(t => t.goodsName)
                .HasMaxLength(150);

            this.Property(t => t.category1No)
                .HasMaxLength(20);

            this.Property(t => t.category2No)
                .HasMaxLength(30);

            this.Property(t => t.category3No)
                .HasMaxLength(50);

            this.Property(t => t.goodsSpec)
                .HasMaxLength(300);

            this.Property(t => t.drugForm)
                .HasMaxLength(500);

            this.Property(t => t.producer)
                .HasMaxLength(100);

            this.Property(t => t.originPlace)
                .HasMaxLength(60);

            this.Property(t => t.packageUnit)
                .HasMaxLength(15);

            this.Property(t => t.supplier_id)
                .HasMaxLength(20);

            this.Property(t => t.supplier_no)
                .HasMaxLength(20);

            this.Property(t => t.supplier_name)
                .HasMaxLength(50);

            this.Property(t => t.rshtqx)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.jsfs)
                .HasMaxLength(100);

            this.Property(t => t.isjh)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.spbctj)
                .HasMaxLength(100);

            this.Property(t => t.yp_syff)
                .HasMaxLength(10);

            this.Property(t => t.storageQty)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.storageQtyZc)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.storageQtyDs)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.storageQtyMd)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.monthlySalesYd)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.stock2useRatio)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.stock2useRatioFilled)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.goodsPrice)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.withtaxPrice)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.lastPrice)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.settlement)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.sfzgys)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.thhbj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("biw_suppliergoods");
            this.Property(t => t.jyzt).HasColumnName("jyzt");
            this.Property(t => t.spx).HasColumnName("spx");
            this.Property(t => t.licenseNo).HasColumnName("licenseNo");
            this.Property(t => t.spid).HasColumnName("spid");
            this.Property(t => t.goodsNo).HasColumnName("goodsNo");
            this.Property(t => t.commonName).HasColumnName("commonName");
            this.Property(t => t.proAddr).HasColumnName("proAddr");
            this.Property(t => t.goodsName).HasColumnName("goodsName");
            this.Property(t => t.category1No).HasColumnName("category1No");
            this.Property(t => t.category2No).HasColumnName("category2No");
            this.Property(t => t.category3No).HasColumnName("category3No");
            this.Property(t => t.goodsSpec).HasColumnName("goodsSpec");
            this.Property(t => t.drugForm).HasColumnName("drugForm");
            this.Property(t => t.producer).HasColumnName("producer");
            this.Property(t => t.originPlace).HasColumnName("originPlace");
            this.Property(t => t.packageUnit).HasColumnName("packageUnit");
            this.Property(t => t.supplier_id).HasColumnName("supplier_id");
            this.Property(t => t.supplier_no).HasColumnName("supplier_no");
            this.Property(t => t.supplier_name).HasColumnName("supplier_name");
            this.Property(t => t.rshtqx).HasColumnName("rshtqx");
            this.Property(t => t.jsfs).HasColumnName("jsfs");
            this.Property(t => t.isjh).HasColumnName("isjh");
            this.Property(t => t.spbctj).HasColumnName("spbctj");
            this.Property(t => t.yp_syff).HasColumnName("yp_syff");
            this.Property(t => t.storageQty).HasColumnName("storageQty");
            this.Property(t => t.storageQtyZc).HasColumnName("storageQtyZc");
            this.Property(t => t.storageQtyDs).HasColumnName("storageQtyDs");
            this.Property(t => t.storageQtyMd).HasColumnName("storageQtyMd");
            this.Property(t => t.monthlySalesYd).HasColumnName("monthlySalesYd");
            this.Property(t => t.stock2useRatio).HasColumnName("stock2useRatio");
            this.Property(t => t.stock2useRatioFilled).HasColumnName("stock2useRatioFilled");
            this.Property(t => t.goodsPrice).HasColumnName("goodsPrice");
            this.Property(t => t.taxRate).HasColumnName("taxRate");
            this.Property(t => t.withtaxPrice).HasColumnName("withtaxPrice");
            this.Property(t => t.lastPrice).HasColumnName("lastPrice");
            this.Property(t => t.settlement).HasColumnName("settlement");
            this.Property(t => t.sfzgys).HasColumnName("sfzgys");
            this.Property(t => t.thhbj).HasColumnName("thhbj");
        }
    }
}
