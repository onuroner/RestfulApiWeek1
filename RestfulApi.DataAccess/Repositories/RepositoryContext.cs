using Microsoft.EntityFrameworkCore;
using RestfulApi.Base.Models;
using RestfulApi.DataAccess.Repositories.DataConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.DataAccess.Repositories
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options) :
            base(options)
        { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Data());
        }
    }
}
