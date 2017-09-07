using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class biw_porders_tMap : EntityTypeConfiguration<biw_porders_t>
    {
        public biw_porders_tMap()
        {
            // Primary Key
            this.HasKey(t => t.poNo);

            // Properties
            this.Property(t => t.poNo)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.creatorName)
                .HasMaxLength(20);

            this.Property(t => t.checker)
                .HasMaxLength(20);

            this.Property(t => t.checktime)
                .HasMaxLength(20);

            this.Property(t => t.arrivedate)
                .HasMaxLength(20);

            this.Property(t => t.dptname)
                .HasMaxLength(20);

            this.Property(t => t.createTime)
                .HasMaxLength(20);

            this.Property(t => t.estimatedArrivalTime)
                .HasMaxLength(20);

            this.Property(t => t.supplierNo)
                .HasMaxLength(20);

            this.Property(t => t.warehouseNo)
                .HasMaxLength(20);

            this.Property(t => t.acceptAddr)
                .HasMaxLength(200);

            this.Property(t => t.skNo)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("biw_porders_t");
            this.Property(t => t.poNo).HasColumnName("poNo");
            this.Property(t => t.creatorName).HasColumnName("creatorName");
            this.Property(t => t.checker).HasColumnName("checker");
            this.Property(t => t.checktime).HasColumnName("checktime");
            this.Property(t => t.arrivedate).HasColumnName("arrivedate");
            this.Property(t => t.dptname).HasColumnName("dptname");
            this.Property(t => t.createTime).HasColumnName("createTime");
            this.Property(t => t.estimatedArrivalTime).HasColumnName("estimatedArrivalTime");
            this.Property(t => t.supplierNo).HasColumnName("supplierNo");
            this.Property(t => t.warehouseNo).HasColumnName("warehouseNo");
            this.Property(t => t.acceptAddr).HasColumnName("acceptAddr");
            this.Property(t => t.purchaseQty).HasColumnName("purchaseQty");
            this.Property(t => t.purchaseAmount).HasColumnName("purchaseAmount");
            this.Property(t => t.taxAmount).HasColumnName("taxAmount");
            this.Property(t => t.totalAmount).HasColumnName("totalAmount");
            this.Property(t => t.isValueadd).HasColumnName("isValueadd");
            this.Property(t => t.isPrestore).HasColumnName("isPrestore");
            this.Property(t => t.skNo).HasColumnName("skNo");
        }
    }
}
