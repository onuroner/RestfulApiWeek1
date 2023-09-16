using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestfulApi.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.DataAccess.Repositories.DataConfig
{
    public class Data : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Title = "Airfryer", Price = 100 },
                new Product { Id = 2, Title = "IPhone", Price = 200 },
                new Product { Id = 3, Title = "Macbook", Price = 300 }
                );
        }
    }
}
