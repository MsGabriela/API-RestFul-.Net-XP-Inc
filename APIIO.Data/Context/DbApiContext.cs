using APIIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIO.Data.Context
{
    public class DbApiContext  : DbContext
    {
        public DbApiContext(DbContextOptions options) : base(options) 
        {
            
        }


        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(200)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbApiContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
