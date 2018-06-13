using System;
using System.Collections.Generic;
using libapp.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace libapp.Data
{
    public class DbInitialize
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibDbContext>();

                var luu = new Customer { Name = "Luu" };
                var dai = new Customer { Name = "Dai" };
                var luong = new Customer { Name = "Luong" };

                context.Customers.Add(luu);
                context.Customers.Add(dai);
                context.Customers.Add(luong);

                var authorLuog = new Author
                {
                    Name = "Luu Dai Luong",
                    Books = new List<Book>
                    {
                        new Book { Title = "Cu lac gion tan"},
                        new Book { Title = "Cuong long giang the"}
                    }
                };

                var authorLuu = new Author
                {
                    Name = "Dai Luong Luu",
                    Books = new List<Book>
                    {
                        new Book { Title = "Cai long ga tay"},
                        new Book { Title = "Cau lam gi the"}
                    }
                };

                context.Authors.Add(authorLuog);
                context.Authors.Add(authorLuu);
                context.SaveChanges();
            }
        }

    }
}
