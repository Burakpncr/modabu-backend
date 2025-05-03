using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ModaBuContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=tcp:modabusqlserver.database.windows.net,1433;Initial Catalog=ModaBuDb01;Persist Security Info=False;User ID=sqladmin;Password=Bu.05.rak35;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Product> Products { get; set; }

    }
}
