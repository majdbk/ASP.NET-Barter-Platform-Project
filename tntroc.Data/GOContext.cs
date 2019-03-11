using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tntroc.Data.Configurations;
using tntroc.Domain.Entities;

namespace tntroc.Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class GOContext : DbContext
    {
        public GOContext() : base("Name=troc")
        {

        }
        
        static GOContext()
        {
            Database.SetInitializer<GOContext>(null);
        }

        public GOContext Create() 
        {
            return new GOContext();
        }


        public DbSet<category> categorys { get; set; }
        public DbSet<claim> claims { get; set; }
        public DbSet<comments> commentss { get; set; }
        public DbSet<exchangeHistory> exchangeHistorys { get; set; }
        public DbSet<forum> forums { get; set; }
        public DbSet<goods> goodss { get; set; }
        public DbSet<subCategory> subCategorys { get; set; }
        public DbSet<swapper> swappers { get; set; }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new configechange());
            modelBuilder.Configurations.Add(new configgoods());
            modelBuilder.Configurations.Add(new configsubcateg());
            
          
        }


    }
}
