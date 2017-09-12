using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BIW_KSOA_Interface.Models.Mapping
{
    public class spkfkMap : EntityTypeConfiguration<spkfk>
    {
        public spkfkMap()
        {
            // Primary Key
            this.HasKey(t => new { t.spid, t.spbh, t.C_MASK_FROM_V2 });

            // Properties
            this.Property(t => t.spid)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.spbh)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.sptm)
                .HasMaxLength(14);

            this.Property(t => t.spmch)
                .HasMaxLength(150);

            this.Property(t => t.zjm)
                .IsFixedLength()
                .HasMaxLength(80);

            this.Property(t => t.beactive)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.yishj)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_gdsj)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_gdzk)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_tjsp)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_hysp)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_gmp)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_gsp)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_sy)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_yp)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.jingd)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.denglrq)
                .HasMaxLength(10);

            this.Property(t => t.gengxshj)
                .HasMaxLength(20);

            this.Property(t => t.delrq)
                .HasMaxLength(10);

            this.Property(t => t.dw)
                .HasMaxLength(15);

            this.Property(t => t.shpchd)
                .IsFixedLength()
                .HasMaxLength(60);

            this.Property(t => t.shpgg)
                .HasMaxLength(300);

            this.Property(t => t.kemuhao)
                .HasMaxLength(20);

            this.Property(t => t.oldcode)
                .HasMaxLength(11);

            this.Property(t => t.rkhw)
                .HasMaxLength(110);

            this.Property(t => t.ckhw)
                .HasMaxLength(11);

            this.Property(t => t.bzqfs)
                .HasMaxLength(8);

            this.Property(t => t.fenlbh)
                .HasMaxLength(20);

            this.Property(t => t.guojbh)
                .HasMaxLength(20);

            this.Property(t => t.changjbh)
                .HasMaxLength(20);

            this.Property(t => t.huaxm)
                .HasMaxLength(40);

            this.Property(t => t.changym)
                .HasMaxLength(30);

            this.Property(t => t.suming)
                .HasMaxLength(60);

            this.Property(t => t.xiwname)
                .HasMaxLength(30);

            this.Property(t => t.tongym)
                .HasMaxLength(150);

            this.Property(t => t.shengccj)
                .HasMaxLength(100);

            this.Property(t => t.pizhwh)
                .HasMaxLength(200);

            this.Property(t => t.zhucsb)
                .HasMaxLength(40);

            this.Property(t => t.jixing)
                .HasMaxLength(500);

            this.Property(t => t.shiyzh)
                .HasMaxLength(30);

            this.Property(t => t.bulfy)
                .HasMaxLength(50);

            this.Property(t => t.chuczysx)
                .IsFixedLength()
                .HasMaxLength(80);

            this.Property(t => t.chuffl)
                .HasMaxLength(12);

            this.Property(t => t.yaofpd)
                .HasMaxLength(8);

            this.Property(t => t.yongfyyl)
                .HasMaxLength(255);

            this.Property(t => t.jinjzh)
                .HasMaxLength(40);

            this.Property(t => t.zhuysx)
                .HasMaxLength(40);

            this.Property(t => t.yaowchf)
                .HasMaxLength(80);

            this.Property(t => t.youxq)
                .HasMaxLength(10);

            this.Property(t => t.shangplx)
                .HasMaxLength(20);

            this.Property(t => t.guizbz)
                .HasMaxLength(10);

            this.Property(t => t.yongyfl)
                .HasMaxLength(14);

            this.Property(t => t.leibie)
                .HasMaxLength(20);

            this.Property(t => t.dispcolor)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.bzgg)
                .HasMaxLength(200);

            this.Property(t => t.lastmodifytime)
                .HasMaxLength(19);

            this.Property(t => t.is_cmd)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.lsgg)
                .HasMaxLength(60);

            this.Property(t => t.is_zdyh)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_jkyp)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_cx_dj)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.zdyh)
                .HasMaxLength(20);

            this.Property(t => t.is_cyhydz)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.nocalcopys)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.fuzr)
                .HasMaxLength(10);

            this.Property(t => t.is_jsh)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_lc)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_zhongyao)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.type_bh)
                .HasMaxLength(50);

            this.Property(t => t.guanjzjh)
                .HasMaxLength(200);

            this.Property(t => t.shiyq)
                .HasMaxLength(10);

            this.Property(t => t.abbrImageURL)
                .HasMaxLength(256);

            this.Property(t => t.cbflbh)
                .HasMaxLength(14);

            this.Property(t => t.imageUrl)
                .HasMaxLength(256);

            this.Property(t => t.is_ybsp)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.yb_spbh)
                .HasMaxLength(15);

            this.Property(t => t.username)
                .HasMaxLength(12);

            this.Property(t => t.zhilbz)
                .HasMaxLength(100);

            this.Property(t => t.chargelb)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.is_sendybzx)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_hj)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_yxbz)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.wdid)
                .HasMaxLength(11);

            this.Property(t => t.chbjs)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.dwbh)
                .HasMaxLength(11);

            this.Property(t => t.zengp)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.beizhu)
                .IsFixedLength()
                .HasMaxLength(40);

            this.Property(t => t.spzt)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.zhongbz)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.cgfzr)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.is_xj)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.yjj_spbh)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.is_cl)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.splx)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.is_yb)
                .HasMaxLength(2);

            this.Property(t => t.is_jifen)
                .HasMaxLength(2);

            this.Property(t => t.is_ggjg)
                .HasMaxLength(2);

            this.Property(t => t.wzzt)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.wzjllb)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.jb1)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.jb2)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.jb3)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.jb4)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.jb5)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.jb6)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.yjfl)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.ejfl)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.sjfl)
                .HasMaxLength(50);

            this.Property(t => t.chuctj)
                .HasMaxLength(80);

            this.Property(t => t.spsx)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.czdjbh)
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.sp_beizhu)
                .IsFixedLength()
                .HasMaxLength(200);

            this.Property(t => t.jysx)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.jyzt)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.qdsx)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.is_bh)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.dwsx)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.jianz)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.isybsp)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_hyrdz)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.old_spbh)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.flbh)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.splb)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.dwmch)
                .IsFixedLength()
                .HasMaxLength(40);

            this.Property(t => t.zgys)
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.zgysbh)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.yp_spbh)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.spx)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.danwbh)
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.dzjgm)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.dsyyr)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.dsyyr2)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.cgmd)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.bhy)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.itemdiameter)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.itemzq)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.itemhd)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.itemhsl)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.is_mhj)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.jwh_lastmodifytime)
                .IsFixedLength()
                .HasMaxLength(19);

            this.Property(t => t.bd_spbh)
                .HasMaxLength(25);

            this.Property(t => t.sptm2)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.sptm3)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.yjjk_spbh)
                .HasMaxLength(50);

            this.Property(t => t.bwm)
                .HasMaxLength(20);

            this.Property(t => t.yjjk_shpgg)
                .HasMaxLength(50);

            this.Property(t => t.C_MASK_FROM_V2)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            this.Property(t => t.thhbj)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.is_dzjg)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.is_ydy)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.schdz)
                .IsFixedLength()
                .HasMaxLength(60);

            this.Property(t => t.spbctj)
                .HasMaxLength(100);

            this.Property(t => t.yuny_tm)
                .HasMaxLength(10);

            this.Property(t => t.yuny_jd)
                .HasMaxLength(10);

            this.Property(t => t.cgr)
                .HasMaxLength(10);

            this.Property(t => t.dhr)
                .HasMaxLength(10);

            this.Property(t => t.ccfl)
                .HasMaxLength(20);

            this.Property(t => t.yp_syff)
                .HasMaxLength(10);

            this.Property(t => t.renq)
                .HasMaxLength(50);

            this.Property(t => t.yp_jixing)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.lylx)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.scqyxkz)
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.gsp_dist)
                .HasMaxLength(20);

            this.Property(t => t.b2cbh)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.b2ccf)
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.CityGSPSpec)
                .HasMaxLength(50);

            this.Property(t => t.is_tgyp)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.y_ejfl)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.y_sjfl)
                .HasMaxLength(50);

            this.Property(t => t.y_yuny_jd)
                .HasMaxLength(10);

            this.Property(t => t.y_yuny_tm)
                .HasMaxLength(10);

            this.Property(t => t.transport_means)
                .HasMaxLength(50);

            this.Property(t => t.lb)
                .HasMaxLength(20);

            this.Property(t => t.sszb)
                .HasMaxLength(20);

            this.Property(t => t.modifier)
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.sfspsx)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.spjylx)
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.is_cfdj)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("spkfk");
            this.Property(t => t.spid).HasColumnName("spid");
            this.Property(t => t.spbh).HasColumnName("spbh");
            this.Property(t => t.sptm).HasColumnName("sptm");
            this.Property(t => t.spmch).HasColumnName("spmch");
            this.Property(t => t.zjm).HasColumnName("zjm");
            this.Property(t => t.beactive).HasColumnName("beactive");
            this.Property(t => t.yishj).HasColumnName("yishj");
            this.Property(t => t.is_gdsj).HasColumnName("is_gdsj");
            this.Property(t => t.is_gdzk).HasColumnName("is_gdzk");
            this.Property(t => t.is_tjsp).HasColumnName("is_tjsp");
            this.Property(t => t.is_hysp).HasColumnName("is_hysp");
            this.Property(t => t.is_gmp).HasColumnName("is_gmp");
            this.Property(t => t.is_gsp).HasColumnName("is_gsp");
            this.Property(t => t.is_sy).HasColumnName("is_sy");
            this.Property(t => t.is_yp).HasColumnName("is_yp");
            this.Property(t => t.jingd).HasColumnName("jingd");
            this.Property(t => t.denglrq).HasColumnName("denglrq");
            this.Property(t => t.gengxshj).HasColumnName("gengxshj");
            this.Property(t => t.delrq).HasColumnName("delrq");
            this.Property(t => t.dw).HasColumnName("dw");
            this.Property(t => t.shpchd).HasColumnName("shpchd");
            this.Property(t => t.shpgg).HasColumnName("shpgg");
            this.Property(t => t.kemuhao).HasColumnName("kemuhao");
            this.Property(t => t.oldcode).HasColumnName("oldcode");
            this.Property(t => t.rkhw).HasColumnName("rkhw");
            this.Property(t => t.ckhw).HasColumnName("ckhw");
            this.Property(t => t.bzqfs).HasColumnName("bzqfs");
            this.Property(t => t.fenlbh).HasColumnName("fenlbh");
            this.Property(t => t.guojbh).HasColumnName("guojbh");
            this.Property(t => t.changjbh).HasColumnName("changjbh");
            this.Property(t => t.huaxm).HasColumnName("huaxm");
            this.Property(t => t.changym).HasColumnName("changym");
            this.Property(t => t.suming).HasColumnName("suming");
            this.Property(t => t.xiwname).HasColumnName("xiwname");
            this.Property(t => t.tongym).HasColumnName("tongym");
            this.Property(t => t.shengccj).HasColumnName("shengccj");
            this.Property(t => t.pizhwh).HasColumnName("pizhwh");
            this.Property(t => t.zhucsb).HasColumnName("zhucsb");
            this.Property(t => t.jixing).HasColumnName("jixing");
            this.Property(t => t.shiyzh).HasColumnName("shiyzh");
            this.Property(t => t.bulfy).HasColumnName("bulfy");
            this.Property(t => t.chuczysx).HasColumnName("chuczysx");
            this.Property(t => t.chuffl).HasColumnName("chuffl");
            this.Property(t => t.yaofpd).HasColumnName("yaofpd");
            this.Property(t => t.yongfyyl).HasColumnName("yongfyyl");
            this.Property(t => t.jinjzh).HasColumnName("jinjzh");
            this.Property(t => t.zhuysx).HasColumnName("zhuysx");
            this.Property(t => t.yaowchf).HasColumnName("yaowchf");
            this.Property(t => t.youxq).HasColumnName("youxq");
            this.Property(t => t.shangplx).HasColumnName("shangplx");
            this.Property(t => t.guizbz).HasColumnName("guizbz");
            this.Property(t => t.yongyfl).HasColumnName("yongyfl");
            this.Property(t => t.leibie).HasColumnName("leibie");
            this.Property(t => t.jlgg).HasColumnName("jlgg");
            this.Property(t => t.otd).HasColumnName("otd");
            this.Property(t => t.ordercycle).HasColumnName("ordercycle");
            this.Property(t => t.stkquot).HasColumnName("stkquot");
            this.Property(t => t.shlv).HasColumnName("shlv");
            this.Property(t => t.hshjj).HasColumnName("hshjj");
            this.Property(t => t.jj).HasColumnName("jj");
            this.Property(t => t.shj).HasColumnName("shj");
            this.Property(t => t.hshsj).HasColumnName("hshsj");
            this.Property(t => t.lshj).HasColumnName("lshj");
            this.Property(t => t.koul).HasColumnName("koul");
            this.Property(t => t.kcsx).HasColumnName("kcsx");
            this.Property(t => t.kcxx).HasColumnName("kcxx");
            this.Property(t => t.helkc).HasColumnName("helkc");
            this.Property(t => t.bzqts).HasColumnName("bzqts");
            this.Property(t => t.yujts).HasColumnName("yujts");
            this.Property(t => t.zgshl).HasColumnName("zgshl");
            this.Property(t => t.zhdcbj).HasColumnName("zhdcbj");
            this.Property(t => t.zdshj).HasColumnName("zdshj");
            this.Property(t => t.zgshj).HasColumnName("zgshj");
            this.Property(t => t.zgjjxz).HasColumnName("zgjjxz");
            this.Property(t => t.maolv).HasColumnName("maolv");
            this.Property(t => t.huiytj).HasColumnName("huiytj");
            this.Property(t => t.itemlength).HasColumnName("itemlength");
            this.Property(t => t.itemheight).HasColumnName("itemheight");
            this.Property(t => t.itemwidth).HasColumnName("itemwidth");
            this.Property(t => t.weight).HasColumnName("weight");
            this.Property(t => t.casevolume).HasColumnName("casevolume");
            this.Property(t => t.caseweight).HasColumnName("caseweight");
            this.Property(t => t.zuixdwtj).HasColumnName("zuixdwtj");
            this.Property(t => t.zuixdwzl).HasColumnName("zuixdwzl");
            this.Property(t => t.pfpj).HasColumnName("pfpj");
            this.Property(t => t.dispcolor).HasColumnName("dispcolor");
            this.Property(t => t.bzgg).HasColumnName("bzgg");
            this.Property(t => t.lastmodifytime).HasColumnName("lastmodifytime");
            this.Property(t => t.is_cmd).HasColumnName("is_cmd");
            this.Property(t => t.lsgg).HasColumnName("lsgg");
            this.Property(t => t.is_zdyh).HasColumnName("is_zdyh");
            this.Property(t => t.is_jkyp).HasColumnName("is_jkyp");
            this.Property(t => t.minshl).HasColumnName("minshl");
            this.Property(t => t.cx_dj_kl).HasColumnName("cx_dj_kl");
            this.Property(t => t.is_cx_dj).HasColumnName("is_cx_dj");
            this.Property(t => t.zdyh).HasColumnName("zdyh");
            this.Property(t => t.zdhyzklshj).HasColumnName("zdhyzklshj");
            this.Property(t => t.is_cyhydz).HasColumnName("is_cyhydz");
            this.Property(t => t.huiyshl).HasColumnName("huiyshl");
            this.Property(t => t.nocalcopys).HasColumnName("nocalcopys");
            this.Property(t => t.fuzr).HasColumnName("fuzr");
            this.Property(t => t.is_jsh).HasColumnName("is_jsh");
            this.Property(t => t.is_lc).HasColumnName("is_lc");
            this.Property(t => t.is_zhongyao).HasColumnName("is_zhongyao");
            this.Property(t => t.type_bh).HasColumnName("type_bh");
            this.Property(t => t.zdlshj).HasColumnName("zdlshj");
            this.Property(t => t.guanjzjh).HasColumnName("guanjzjh");
            this.Property(t => t.shiyq).HasColumnName("shiyq");
            this.Property(t => t.abbrImageURL).HasColumnName("abbrImageURL");
            this.Property(t => t.cbflbh).HasColumnName("cbflbh");
            this.Property(t => t.imageUrl).HasColumnName("imageUrl");
            this.Property(t => t.is_ybsp).HasColumnName("is_ybsp");
            this.Property(t => t.yb_zfbl).HasColumnName("yb_zfbl");
            this.Property(t => t.yb_spbh).HasColumnName("yb_spbh");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.chuchj).HasColumnName("chuchj");
            this.Property(t => t.pifj).HasColumnName("pifj");
            this.Property(t => t.zhilbz).HasColumnName("zhilbz");
            this.Property(t => t.chargelb).HasColumnName("chargelb");
            this.Property(t => t.is_sendybzx).HasColumnName("is_sendybzx");
            this.Property(t => t.tj_ylshj).HasColumnName("tj_ylshj");
            this.Property(t => t.is_hj).HasColumnName("is_hj");
            this.Property(t => t.is_yxbz).HasColumnName("is_yxbz");
            this.Property(t => t.wdid).HasColumnName("wdid");
            this.Property(t => t.chbjs).HasColumnName("chbjs");
            this.Property(t => t.dwbh).HasColumnName("dwbh");
            this.Property(t => t.zengp).HasColumnName("zengp");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.spzt).HasColumnName("spzt");
            this.Property(t => t.zhongbz).HasColumnName("zhongbz");
            this.Property(t => t.cgfzr).HasColumnName("cgfzr");
            this.Property(t => t.is_xj).HasColumnName("is_xj");
            this.Property(t => t.hyj).HasColumnName("hyj");
            this.Property(t => t.yjj_spbh).HasColumnName("yjj_spbh");
            this.Property(t => t.is_cl).HasColumnName("is_cl");
            this.Property(t => t.jifen).HasColumnName("jifen");
            this.Property(t => t.hyj1).HasColumnName("hyj1");
            this.Property(t => t.hyj2).HasColumnName("hyj2");
            this.Property(t => t.hyj3).HasColumnName("hyj3");
            this.Property(t => t.nhyj).HasColumnName("nhyj");
            this.Property(t => t.yhyj).HasColumnName("yhyj");
            this.Property(t => t.nhyj1).HasColumnName("nhyj1");
            this.Property(t => t.nhyj2).HasColumnName("nhyj2");
            this.Property(t => t.nhyj3).HasColumnName("nhyj3");
            this.Property(t => t.splx).HasColumnName("splx");
            this.Property(t => t.sp_hyjf).HasColumnName("sp_hyjf");
            this.Property(t => t.is_yb).HasColumnName("is_yb");
            this.Property(t => t.is_jifen).HasColumnName("is_jifen");
            this.Property(t => t.is_ggjg).HasColumnName("is_ggjg");
            this.Property(t => t.wzzt).HasColumnName("wzzt");
            this.Property(t => t.wzjllb).HasColumnName("wzjllb");
            this.Property(t => t.jb1).HasColumnName("jb1");
            this.Property(t => t.jb2).HasColumnName("jb2");
            this.Property(t => t.jb3).HasColumnName("jb3");
            this.Property(t => t.jb4).HasColumnName("jb4");
            this.Property(t => t.jb5).HasColumnName("jb5");
            this.Property(t => t.jb6).HasColumnName("jb6");
            this.Property(t => t.yjfl).HasColumnName("yjfl");
            this.Property(t => t.ejfl).HasColumnName("ejfl");
            this.Property(t => t.sjfl).HasColumnName("sjfl");
            this.Property(t => t.chuctj).HasColumnName("chuctj");
            this.Property(t => t.zglshj).HasColumnName("zglshj");
            this.Property(t => t.spsx).HasColumnName("spsx");
            this.Property(t => t.czdjbh).HasColumnName("czdjbh");
            this.Property(t => t.sp_beizhu).HasColumnName("sp_beizhu");
            this.Property(t => t.jysx).HasColumnName("jysx");
            this.Property(t => t.jyzt).HasColumnName("jyzt");
            this.Property(t => t.qdsx).HasColumnName("qdsx");
            this.Property(t => t.is_bh).HasColumnName("is_bh");
            this.Property(t => t.dwsx).HasColumnName("dwsx");
            this.Property(t => t.tcdj).HasColumnName("tcdj");
            this.Property(t => t.tcxs).HasColumnName("tcxs");
            this.Property(t => t.jianz).HasColumnName("jianz");
            this.Property(t => t.isybsp).HasColumnName("isybsp");
            this.Property(t => t.ydj).HasColumnName("ydj");
            this.Property(t => t.is_hyrdz).HasColumnName("is_hyrdz");
            this.Property(t => t.old_spbh).HasColumnName("old_spbh");
            this.Property(t => t.flbh).HasColumnName("flbh");
            this.Property(t => t.zdcll).HasColumnName("zdcll");
            this.Property(t => t.shzq).HasColumnName("shzq");
            this.Property(t => t.splb).HasColumnName("splb");
            this.Property(t => t.dwmch).HasColumnName("dwmch");
            this.Property(t => t.zgys).HasColumnName("zgys");
            this.Property(t => t.xshlv).HasColumnName("xshlv");
            this.Property(t => t.zgysbh).HasColumnName("zgysbh");
            this.Property(t => t.yp_spbh).HasColumnName("yp_spbh");
            this.Property(t => t.spx).HasColumnName("spx");
            this.Property(t => t.danwbh).HasColumnName("danwbh");
            this.Property(t => t.dzjgm).HasColumnName("dzjgm");
            this.Property(t => t.dsyyr).HasColumnName("dsyyr");
            this.Property(t => t.dsyyr2).HasColumnName("dsyyr2");
            this.Property(t => t.cgmd).HasColumnName("cgmd");
            this.Property(t => t.bhy).HasColumnName("bhy");
            this.Property(t => t.dszb).HasColumnName("dszb");
            this.Property(t => t.mdkcxx).HasColumnName("mdkcxx");
            this.Property(t => t.itemdiameter).HasColumnName("itemdiameter");
            this.Property(t => t.itemzq).HasColumnName("itemzq");
            this.Property(t => t.itemhd).HasColumnName("itemhd");
            this.Property(t => t.itemhsl).HasColumnName("itemhsl");
            this.Property(t => t.is_mhj).HasColumnName("is_mhj");
            this.Property(t => t.jwh_lastmodifytime).HasColumnName("jwh_lastmodifytime");
            this.Property(t => t.bzdj).HasColumnName("bzdj");
            this.Property(t => t.bd_spbh).HasColumnName("bd_spbh");
            this.Property(t => t.sptm2).HasColumnName("sptm2");
            this.Property(t => t.sptm3).HasColumnName("sptm3");
            this.Property(t => t.yjjk_spbh).HasColumnName("yjjk_spbh");
            this.Property(t => t.bwm).HasColumnName("bwm");
            this.Property(t => t.yjjk_shpgg).HasColumnName("yjjk_shpgg");
            this.Property(t => t.C_MASK_FROM_V2).HasColumnName("_MASK_FROM_V2");
            this.Property(t => t.thhbj).HasColumnName("thhbj");
            this.Property(t => t.istofw).HasColumnName("istofw");
            this.Property(t => t.isfwytb).HasColumnName("isfwytb");
            this.Property(t => t.is_dzjg).HasColumnName("is_dzjg");
            this.Property(t => t.is_ydy).HasColumnName("is_ydy");
            this.Property(t => t.schdz).HasColumnName("schdz");
            this.Property(t => t.spbctj).HasColumnName("spbctj");
            this.Property(t => t.yuny_tm).HasColumnName("yuny_tm");
            this.Property(t => t.yuny_jd).HasColumnName("yuny_jd");
            this.Property(t => t.cgr).HasColumnName("cgr");
            this.Property(t => t.dhr).HasColumnName("dhr");
            this.Property(t => t.ccfl).HasColumnName("ccfl");
            this.Property(t => t.yp_syff).HasColumnName("yp_syff");
            this.Property(t => t.renq).HasColumnName("renq");
            this.Property(t => t.jianz2).HasColumnName("jianz2");
            this.Property(t => t.yp_jixing).HasColumnName("yp_jixing");
            this.Property(t => t.dbzc).HasColumnName("dbzc");
            this.Property(t => t.dbzg).HasColumnName("dbzg");
            this.Property(t => t.dbzk).HasColumnName("dbzk");
            this.Property(t => t.lylx).HasColumnName("lylx");
            this.Property(t => t.scqyxkz).HasColumnName("scqyxkz");
            this.Property(t => t.gsp_dist).HasColumnName("gsp_dist");
            this.Property(t => t.b2cbh).HasColumnName("b2cbh");
            this.Property(t => t.b2ccf).HasColumnName("b2ccf");
            this.Property(t => t.CityGSPSpec).HasColumnName("CityGSPSpec");
            this.Property(t => t.updateTime).HasColumnName("updateTime");
            this.Property(t => t.is_tgyp).HasColumnName("is_tgyp");
            this.Property(t => t.y_ejfl).HasColumnName("y_ejfl");
            this.Property(t => t.y_sjfl).HasColumnName("y_sjfl");
            this.Property(t => t.y_yuny_jd).HasColumnName("y_yuny_jd");
            this.Property(t => t.y_yuny_tm).HasColumnName("y_yuny_tm");
            this.Property(t => t.transport_means).HasColumnName("transport_means");
            this.Property(t => t.lb).HasColumnName("lb");
            this.Property(t => t.sszb).HasColumnName("sszb");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.spjcfl).HasColumnName("spjcfl");
            this.Property(t => t.sfspsx).HasColumnName("sfspsx");
            this.Property(t => t.spjylx).HasColumnName("spjylx");
            this.Property(t => t.is_cfdj).HasColumnName("is_cfdj");
        }
    }
}
