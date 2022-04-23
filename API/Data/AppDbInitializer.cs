using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (context != null) 
                {
                    /// create database if not exists
                    context.Database.Migrate();

                    /// only insert data if table is empty
                    if (!context.Products.Any()) {
                        context.Products.AddRange(new List<Product>()
                        {
                            new Product()
                            {
                                Name = "Product one"
                            },
                            new Product()
                            {
                                Name = "Product two"
                            },
                            new Product()
                            {
                                Name = "Product three"
                            }
                        });

                        context.SaveChanges();
                    }
                }
            }
        }
    }
}