using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleTelerikApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SimpleTelerikApp.Data
{
    public class FilmsContext : DbContext
    {
        public FilmsContext() : base("FilmsContext") { }

        public DbSet<Films> Films { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}