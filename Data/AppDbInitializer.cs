using DotNetCoreLearnProj.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLearnProj.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        gener = "Biography",
                        CoverUrl = "http...",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        title = "2nd Book Title",
                        Description = "2nd Book Description",
                        IsRead = true,
                        gener = "Biography",
                        CoverUrl = "http...",
                        DateAdded = DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
