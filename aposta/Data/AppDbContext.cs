using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Aposta.Models;

namespace Aposta.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ApostaModel> Apostas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");


    }
}