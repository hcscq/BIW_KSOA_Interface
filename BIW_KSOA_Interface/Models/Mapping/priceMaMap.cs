using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class priceMaMap : EntityTypeConfiguration<priceMa>
    {
        public priceMaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.gzid, t.dj_sn, t.flag });

            // Properties
            this.Property(t => t.gzid)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.dj_sn)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.spid)
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.spbh)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.spmch)
                .HasMaxLength(150);

            this.Property(t => t.shpgg)
                .HasMaxLength(300);

            this.Property(t => t.shpchd)
                .IsFixedLength()
                .HasMaxLength(60);

            this.Property(t => t.dw)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.is_zgys)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_del)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.leibei)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.jsfs)
                .HasMaxLength(100);

            this.Property(t => t.fuzr)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.thhbj)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.danwbh)
                .HasMaxLength(30);

            this.Property(t => t.orderId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("priceMa");
            this.Property(t => t.gzid).HasColumnName("gzid");
            this.Property(t => t.dj_sn).HasColumnName("dj_sn");
            this.Property(t => t.dj_sort).HasColumnName("dj_sort");
            this.Property(t => t.spid).HasColumnName("spid");
            this.Property(t => t.spbh).HasColumnName("spbh");
            this.Property(t => t.spmch).HasColumnName("spmch");
            this.Property(t => t.shpgg).HasColumnName("shpgg");
            this.Property(t => t.shpchd).HasColumnName("shpchd");
            this.Property(t => t.dw).HasColumnName("dw");
            this.Property(t => t.ydj).HasColumnName("ydj");
            this.Property(t => t.hshjj).HasColumnName("hshjj");
            this.Property(t => t.shlv).HasColumnName("shlv");
            this.Property(t => t.ndj).HasColumnName("ndj");
            this.Property(t => t.zhjj).HasColumnName("zhjj");
            this.Property(t => t.jjcy).HasColumnName("jjcy");
            this.Property(t => t.is_zgys).HasColumnName("is_zgys");
            this.Property(t => t.is_del).HasColumnName("is_del");
            this.Property(t => t.dj).HasColumnName("dj");
            this.Property(t => t.tmpdj).HasColumnName("tmpdj");
            this.Property(t => t.leibei).HasColumnName("leibei");
            this.Property(t => t.jsfs).HasColumnName("jsfs");
            this.Property(t => t.fuzr).HasColumnName("fuzr");
            this.Property(t => t.tianshu).HasColumnName("tianshu");
            this.Property(t => t.thhbj).HasColumnName("thhbj");
            this.Property(t => t.danwbh).HasColumnName("danwbh");
            this.Property(t => t.hyj).HasColumnName("hyj");
            this.Property(t => t.insertDate).HasColumnName("insertDate");
            this.Property(t => t.flag).HasColumnName("flag");
            this.Property(t => t.orderId).HasColumnName("orderId");
        }
    }
}
