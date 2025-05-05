using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ModaBuContext : DbContext
    {
        public ModaBuContext() { }

        // 2) DI ile gelen ctor (senin zaten vardı)
        public ModaBuContext(DbContextOptions<ModaBuContext> options)
            : base(options)
        {
        }

        // 3) Parametresiz kullanım için OnConfiguring’i geri ekle
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // appsettings.json’dan veya ENV’den oku
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                var cs = config.GetConnectionString("DefaultConnection");
                if (!string.IsNullOrWhiteSpace(cs))
                {
                    optionsBuilder.UseSqlServer(cs);
                }
                // yoksa istersen burada sabit bir connection string de koyabilirsin
            }
        }

        // -- DbSet’lerin
        public DbSet<Product> Products { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
