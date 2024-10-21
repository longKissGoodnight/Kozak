/*using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozak.PredictModel
{
    public class CryptoContext : DbContext
    {
        public DbSet<CryptoPrice> CryptoPrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=CryptoDB;Username=yourusername;Password=yourpassword");
        }
    }

}*/
