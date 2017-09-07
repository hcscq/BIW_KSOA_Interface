using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BIW_KSOA_Interface.Models.Mapping;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace BIW_KSOA_Interface.Models
{
    public partial class BIW_KSOAContext : DbContext
    {
        static BIW_KSOAContext()
        {
            Database.SetInitializer<BIW_KSOAContext>(null);
        }

        public BIW_KSOAContext()
            : base("Name=BIW_KSOAContext")
        {
        }

        public DbSet<biw_porders_d> biw_porders_d { get; set; }
        public DbSet<biw_porders_t> biw_porders_t { get; set; }
        public DbSet<Biw_ReturnPoD> Biw_ReturnPoD { get; set; }
        public DbSet<Biw_ReturnPoM> Biw_ReturnPoM { get; set; }
        public DbSet<priceMa> priceMas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new biw_porders_dMap());
            modelBuilder.Configurations.Add(new biw_porders_tMap());
            modelBuilder.Configurations.Add(new Biw_ReturnPoDMap());
            modelBuilder.Configurations.Add(new Biw_ReturnPoMMap());
            modelBuilder.Configurations.Add(new priceMaMap());

        }
        public IEnumerable<TElement> ProcedureQuery<TElement>(string sp)
        {
            string sql = "";
            List<TElement> items = new List<TElement>();



            sql = "EXEC " + sp + " ";
            var tempResult = this.Database.SqlQuery<TElement>(sql);
            if (tempResult != null)
            {
                items.AddRange(tempResult);
            }

            return items;
        }

        public  int ProcedureQuery(string sp, params SqlParameter[] parameters)
        {
            using (var context = this)
            {
                using (context.Database.Connection)
                {
                    context.Database.Connection.Open();
                    var cmd = context.Database.Connection.CreateCommand();
                    cmd.CommandText = sp;
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
