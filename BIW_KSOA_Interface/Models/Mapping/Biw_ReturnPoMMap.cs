using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class Biw_ReturnPoMMap : EntityTypeConfiguration<Biw_ReturnPoM>
    {
        public Biw_ReturnPoMMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ReturnPoNo, t.SupplierNo, t.CreatorName, t.CreatorPart, t.CreateDate, t.InsertDate,t.Reason });

            // Properties
            this.Property(t => t.ReturnPoNo)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.SupplierNo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CreatorName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CreatorPart)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Note)
                .HasMaxLength(150);

            this.Property(t => t.Reason)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Biw_ReturnPoM");
            this.Property(t => t.ReturnPoNo).HasColumnName("ReturnPoNo");
            this.Property(t => t.SupplierNo).HasColumnName("SupplierNo");
            this.Property(t => t.CreatorName).HasColumnName("CreatorName");
            this.Property(t => t.CreatorPart).HasColumnName("CreatorPart");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.InsertDate).HasColumnName("InsertDate");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.Reason).HasColumnName("Reason");
        }
       
    }
}
