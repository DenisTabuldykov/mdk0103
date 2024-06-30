using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Practica13_33.Models
{
    public class DataBase : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Tovar> Tovars { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"FileName=database.db3");
        }
        public DataBase()
        {
            if (File.Exists("database.db3") != true)
            {
                Database.EnsureCreated();
            }
        }
    }
}
