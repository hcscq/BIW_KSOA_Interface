using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class mchkMap : EntityTypeConfiguration<mchk>
    {
        public mchkMap()
        {
            // Primary Key
            this.HasKey(t => t.dwbh);

            // Properties
            this.Property(t => t.dwbh)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.danwbh)
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.dwmch)
                .HasMaxLength(50);

            this.Property(t => t.zjm)
                .IsFixedLength()
                .HasMaxLength(80);

            this.Property(t => t.kemuhao)
                .HasMaxLength(20);

            this.Property(t => t.ywy)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.kehufl)
                .HasMaxLength(20);

            this.Property(t => t.quyufl)
                .HasMaxLength(20);

            this.Property(t => t.kehulb)
                .HasMaxLength(12);

            this.Property(t => t.isjh)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.isxs)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.shh)
                .HasMaxLength(45);

            this.Property(t => t.dzhdh)
                .HasMaxLength(150);

            this.Property(t => t.yhzhh)
                .HasMaxLength(40);

            this.Property(t => t.lxr)
                .HasMaxLength(15);

            this.Property(t => t.zipno)
                .HasMaxLength(6);

            this.Property(t => t.kehudengji)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.lxrdh)
                .HasMaxLength(50);

            this.Property(t => t.beactive)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.oldcode)
                .HasMaxLength(11);

            this.Property(t => t.yishj)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.xvkz)
                .HasMaxLength(200);

            this.Property(t => t.shfyyzz)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.yingyzz)
                .IsFixedLength()
                .HasMaxLength(25);

            this.Property(t => t.jingyfw)
                .HasMaxLength(512);

            this.Property(t => t.hangymch)
                .HasMaxLength(20);

            this.Property(t => t.frdb)
                .HasMaxLength(20);

            this.Property(t => t.heshitg)
                .HasMaxLength(10);

            this.Property(t => t.zhj_dh)
                .HasMaxLength(10);

            this.Property(t => t.is_zhdshg)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.zjxpzh)
                .HasMaxLength(60);

            this.Property(t => t.is_pxrz)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_wf)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.zhuypzh)
                .HasMaxLength(200);

            this.Property(t => t.is_xkz)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_yyzz)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_shqwtsh)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_shgzh)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_shfzh)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_lxdh)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_zhlbzhxy)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_jq)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_gb)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_jg)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.qita)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.bmyj)
                .HasMaxLength(20);

            this.Property(t => t.zhj_yj)
                .HasMaxLength(20);

            this.Property(t => t.zhgshp)
                .HasMaxLength(20);

            this.Property(t => t.tbrq)
                .HasMaxLength(10);

            this.Property(t => t.zhlfzr)
                .HasMaxLength(10);

            this.Property(t => t.culture)
                .HasMaxLength(16);

            this.Property(t => t.zhibumen)
                .HasMaxLength(20);

            this.Property(t => t.shenhrq)
                .HasMaxLength(10);

            this.Property(t => t.xkzyxq)
                .HasMaxLength(10);

            this.Property(t => t.gspzsyxq)
                .HasMaxLength(10);

            this.Property(t => t.gmpzsyxq)
                .HasMaxLength(10);

            this.Property(t => t.khyh)
                .HasMaxLength(60);

            this.Property(t => t.dzdh)
                .HasMaxLength(120);

            this.Property(t => t.psdzm)
                .HasMaxLength(15);

            this.Property(t => t.lastmodifytime)
                .HasMaxLength(19);

            this.Property(t => t.czcaozy)
                .HasMaxLength(10);

            this.Property(t => t.idcard)
                .HasMaxLength(18);

            this.Property(t => t.xvkzname)
                .HasMaxLength(40);

            this.Property(t => t.fzhjg)
                .HasMaxLength(40);

            this.Property(t => t.fzhrq)
                .HasMaxLength(10);

            this.Property(t => t.yyzzdjjg)
                .HasMaxLength(40);

            this.Property(t => t.shwdjh)
                .HasMaxLength(40);

            this.Property(t => t.jyfsh)
                .HasMaxLength(40);

            this.Property(t => t.zlzhshbh)
                .HasMaxLength(40);

            this.Property(t => t.limitTime)
                .HasMaxLength(10);

            this.Property(t => t.gmpzsh)
                .HasMaxLength(12);

            this.Property(t => t.faxno)
                .HasMaxLength(20);

            this.Property(t => t.yyzzyxq)
                .HasMaxLength(10);

            this.Property(t => t.jsfs)
                .HasMaxLength(100);

            this.Property(t => t.zhangq)
                .IsFixedLength()
                .HasMaxLength(40);

            this.Property(t => t.fkfs)
                .IsFixedLength()
                .HasMaxLength(40);

            this.Property(t => t.qyzg)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.qyxy)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.rshtqx)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.heth)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.zljryy)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.zljjyy)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.htzht)
                .HasMaxLength(10);

            this.Property(t => t.htlx)
                .HasMaxLength(10);

            this.Property(t => t.is_dujia)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.htkshrq)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.htjshrq)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.phje)
                .HasMaxLength(20);

            this.Property(t => t.flshj)
                .HasMaxLength(10);

            this.Property(t => t.flrwl)
                .HasMaxLength(100);

            this.Property(t => t.fle)
                .HasMaxLength(100);

            this.Property(t => t.flzfshj)
                .HasMaxLength(100);

            this.Property(t => t.fltj)
                .HasMaxLength(100);

            this.Property(t => t.fylx)
                .HasMaxLength(20);

            this.Property(t => t.fye)
                .HasMaxLength(20);

            this.Property(t => t.fyzfshj)
                .HasMaxLength(50);

            this.Property(t => t.beizhu)
                .IsFixedLength()
                .HasMaxLength(200);

            this.Property(t => t.is_thh)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.yyzznjnf)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.frsqwtsyxq)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.bwtr)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.bwtrsfzyxq)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.zlbzxysyxq)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.ypscpjyxq)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.yjjk_dwbh)
                .HasMaxLength(50);

            this.Property(t => t.yjjk_dwmch)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.zzjgdmz)
                .HasMaxLength(30);

            this.Property(t => t.is_wlgs)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.caozy)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("mchk");
            this.Property(t => t.dwbh).HasColumnName("dwbh");
            this.Property(t => t.danwbh).HasColumnName("danwbh");
            this.Property(t => t.dwmch).HasColumnName("dwmch");
            this.Property(t => t.zjm).HasColumnName("zjm");
            this.Property(t => t.kemuhao).HasColumnName("kemuhao");
            this.Property(t => t.ywy).HasColumnName("ywy");
            this.Property(t => t.kehufl).HasColumnName("kehufl");
            this.Property(t => t.quyufl).HasColumnName("quyufl");
            this.Property(t => t.kehulb).HasColumnName("kehulb");
            this.Property(t => t.isjh).HasColumnName("isjh");
            this.Property(t => t.isxs).HasColumnName("isxs");
            this.Property(t => t.shh).HasColumnName("shh");
            this.Property(t => t.dzhdh).HasColumnName("dzhdh");
            this.Property(t => t.yhzhh).HasColumnName("yhzhh");
            this.Property(t => t.lxr).HasColumnName("lxr");
            this.Property(t => t.zipno).HasColumnName("zipno");
            this.Property(t => t.kehudengji).HasColumnName("kehudengji");
            this.Property(t => t.lxrdh).HasColumnName("lxrdh");
            this.Property(t => t.ghxde).HasColumnName("ghxde");
            this.Property(t => t.xsxde).HasColumnName("xsxde");
            this.Property(t => t.otd).HasColumnName("otd");
            this.Property(t => t.xdqxg).HasColumnName("xdqxg");
            this.Property(t => t.xdqxx).HasColumnName("xdqxx");
            this.Property(t => t.koul).HasColumnName("koul");
            this.Property(t => t.canskl).HasColumnName("canskl");
            this.Property(t => t.yshye).HasColumnName("yshye");
            this.Property(t => t.yfye).HasColumnName("yfye");
            this.Property(t => t.yingshsx).HasColumnName("yingshsx");
            this.Property(t => t.yshjzh).HasColumnName("yshjzh");
            this.Property(t => t.yfjzh).HasColumnName("yfjzh");
            this.Property(t => t.beactive).HasColumnName("beactive");
            this.Property(t => t.oldcode).HasColumnName("oldcode");
            this.Property(t => t.yishj).HasColumnName("yishj");
            this.Property(t => t.xvkz).HasColumnName("xvkz");
            this.Property(t => t.shfyyzz).HasColumnName("shfyyzz");
            this.Property(t => t.yingyzz).HasColumnName("yingyzz");
            this.Property(t => t.jingyfw).HasColumnName("jingyfw");
            this.Property(t => t.hangymch).HasColumnName("hangymch");
            this.Property(t => t.oldyfye).HasColumnName("oldyfye");
            this.Property(t => t.oldyshye).HasColumnName("oldyshye");
            this.Property(t => t.frdb).HasColumnName("frdb");
            this.Property(t => t.zhgzsh).HasColumnName("zhgzsh");
            this.Property(t => t.zhj_bl).HasColumnName("zhj_bl");
            this.Property(t => t.shn_xshe).HasColumnName("shn_xshe");
            this.Property(t => t.heshitg).HasColumnName("heshitg");
            this.Property(t => t.pzhshl).HasColumnName("pzhshl");
            this.Property(t => t.zhj_dh).HasColumnName("zhj_dh");
            this.Property(t => t.is_zhdshg).HasColumnName("is_zhdshg");
            this.Property(t => t.zjxpzh).HasColumnName("zjxpzh");
            this.Property(t => t.is_pxrz).HasColumnName("is_pxrz");
            this.Property(t => t.is_wf).HasColumnName("is_wf");
            this.Property(t => t.zhuypzh).HasColumnName("zhuypzh");
            this.Property(t => t.is_xkz).HasColumnName("is_xkz");
            this.Property(t => t.is_yyzz).HasColumnName("is_yyzz");
            this.Property(t => t.is_shqwtsh).HasColumnName("is_shqwtsh");
            this.Property(t => t.is_shgzh).HasColumnName("is_shgzh");
            this.Property(t => t.is_shfzh).HasColumnName("is_shfzh");
            this.Property(t => t.is_lxdh).HasColumnName("is_lxdh");
            this.Property(t => t.is_zhlbzhxy).HasColumnName("is_zhlbzhxy");
            this.Property(t => t.is_jq).HasColumnName("is_jq");
            this.Property(t => t.is_gb).HasColumnName("is_gb");
            this.Property(t => t.is_jg).HasColumnName("is_jg");
            this.Property(t => t.qita).HasColumnName("qita");
            this.Property(t => t.bmyj).HasColumnName("bmyj");
            this.Property(t => t.zhj_yj).HasColumnName("zhj_yj");
            this.Property(t => t.zhgshp).HasColumnName("zhgshp");
            this.Property(t => t.tbrq).HasColumnName("tbrq");
            this.Property(t => t.zhlfzr).HasColumnName("zhlfzr");
            this.Property(t => t.shn_hgl).HasColumnName("shn_hgl");
            this.Property(t => t.culture).HasColumnName("culture");
            this.Property(t => t.zhibumen).HasColumnName("zhibumen");
            this.Property(t => t.shenhrq).HasColumnName("shenhrq");
            this.Property(t => t.xkzyxq).HasColumnName("xkzyxq");
            this.Property(t => t.gspzsyxq).HasColumnName("gspzsyxq");
            this.Property(t => t.gmpzsyxq).HasColumnName("gmpzsyxq");
            this.Property(t => t.khyh).HasColumnName("khyh");
            this.Property(t => t.dzdh).HasColumnName("dzdh");
            this.Property(t => t.psdzm).HasColumnName("psdzm");
            this.Property(t => t.lastmodifytime).HasColumnName("lastmodifytime");
            this.Property(t => t.czcaozy).HasColumnName("czcaozy");
            this.Property(t => t.idcard).HasColumnName("idcard");
            this.Property(t => t.xvkzname).HasColumnName("xvkzname");
            this.Property(t => t.fzhjg).HasColumnName("fzhjg");
            this.Property(t => t.fzhrq).HasColumnName("fzhrq");
            this.Property(t => t.yyzzdjjg).HasColumnName("yyzzdjjg");
            this.Property(t => t.reg_capital).HasColumnName("reg_capital");
            this.Property(t => t.shwdjh).HasColumnName("shwdjh");
            this.Property(t => t.jyfsh).HasColumnName("jyfsh");
            this.Property(t => t.zlzhshbh).HasColumnName("zlzhshbh");
            this.Property(t => t.limitTime).HasColumnName("limitTime");
            this.Property(t => t.gonghnl).HasColumnName("gonghnl");
            this.Property(t => t.gmpzsh).HasColumnName("gmpzsh");
            this.Property(t => t.faxno).HasColumnName("faxno");
            this.Property(t => t.yusye).HasColumnName("yusye");
            this.Property(t => t.yufye).HasColumnName("yufye");
            this.Property(t => t.flye).HasColumnName("flye");
            this.Property(t => t.yyzzyxq).HasColumnName("yyzzyxq");
            this.Property(t => t.chnjsts).HasColumnName("chnjsts");
            this.Property(t => t.jsfs).HasColumnName("jsfs");
            this.Property(t => t.zhangq).HasColumnName("zhangq");
            this.Property(t => t.fkfs).HasColumnName("fkfs");
            this.Property(t => t.qyzg).HasColumnName("qyzg");
            this.Property(t => t.qyxy).HasColumnName("qyxy");
            this.Property(t => t.rshtqx).HasColumnName("rshtqx");
            this.Property(t => t.heth).HasColumnName("heth");
            this.Property(t => t.zljryy).HasColumnName("zljryy");
            this.Property(t => t.zljjyy).HasColumnName("zljjyy");
            this.Property(t => t.htzht).HasColumnName("htzht");
            this.Property(t => t.htlx).HasColumnName("htlx");
            this.Property(t => t.is_dujia).HasColumnName("is_dujia");
            this.Property(t => t.htkshrq).HasColumnName("htkshrq");
            this.Property(t => t.htjshrq).HasColumnName("htjshrq");
            this.Property(t => t.phje).HasColumnName("phje");
            this.Property(t => t.flshj).HasColumnName("flshj");
            this.Property(t => t.flrwl).HasColumnName("flrwl");
            this.Property(t => t.fle).HasColumnName("fle");
            this.Property(t => t.flzfshj).HasColumnName("flzfshj");
            this.Property(t => t.fltj).HasColumnName("fltj");
            this.Property(t => t.fylx).HasColumnName("fylx");
            this.Property(t => t.fye).HasColumnName("fye");
            this.Property(t => t.fyzfshj).HasColumnName("fyzfshj");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.is_thh).HasColumnName("is_thh");
            this.Property(t => t.yyzznjnf).HasColumnName("yyzznjnf");
            this.Property(t => t.frsqwtsyxq).HasColumnName("frsqwtsyxq");
            this.Property(t => t.bwtr).HasColumnName("bwtr");
            this.Property(t => t.bwtrsfzyxq).HasColumnName("bwtrsfzyxq");
            this.Property(t => t.zlbzxysyxq).HasColumnName("zlbzxysyxq");
            this.Property(t => t.ypscpjyxq).HasColumnName("ypscpjyxq");
            this.Property(t => t.yjjk_dwbh).HasColumnName("yjjk_dwbh");
            this.Property(t => t.yjjk_dwmch).HasColumnName("yjjk_dwmch");
            this.Property(t => t.zzjgdmz).HasColumnName("zzjgdmz");
            this.Property(t => t.is_wlgs).HasColumnName("is_wlgs");
            this.Property(t => t.caozy).HasColumnName("caozy");
        }
    }
}
