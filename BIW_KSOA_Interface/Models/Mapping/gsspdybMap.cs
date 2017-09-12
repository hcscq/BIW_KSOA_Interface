using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class gsspdybMap : EntityTypeConfiguration<gsspdyb>
    {
        public gsspdybMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.dwbh, t.spid });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.djbh)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.rq)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.username)
                .IsFixedLength()
                .HasMaxLength(12);

            this.Property(t => t.dwbh)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.spid)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.zhilzhk)
                .IsFixedLength()
                .HasMaxLength(20);

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

            // Table & Column Mappings
            this.ToTable("gsspdyb");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.djbh).HasColumnName("djbh");
            this.Property(t => t.rq).HasColumnName("rq");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.dwbh).HasColumnName("dwbh");
            this.Property(t => t.spid).HasColumnName("spid");
            this.Property(t => t.ydj).HasColumnName("ydj");
            this.Property(t => t.ndj).HasColumnName("ndj");
            this.Property(t => t.shlv).HasColumnName("shlv");
            this.Property(t => t.hshjj).HasColumnName("hshjj");
            this.Property(t => t.zhilzhk).HasColumnName("zhilzhk");
            this.Property(t => t.is_del).HasColumnName("is_del");
            this.Property(t => t.tianshu).HasColumnName("tianshu");
            this.Property(t => t.leibei).HasColumnName("leibei");
            this.Property(t => t.jsfs).HasColumnName("jsfs");
            this.Property(t => t.fuzr).HasColumnName("fuzr");
            this.Property(t => t.thhbj).HasColumnName("thhbj");
            this.Property(t => t.zhjj).HasColumnName("zhjj");
            this.Property(t => t.jjcy).HasColumnName("jjcy");
        }
    }
}
