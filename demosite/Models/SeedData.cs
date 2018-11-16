using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace demosite.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new demositeContext(
                serviceProvider.GetRequiredService<DbContextOptions<demositeContext>>()))
            {
                if (context.Facility.Any())
                {
                    return;   // DB has been seeded
                }

                context.Facility.AddRange(
                    new Facility
                    {
                        People = "Jay",
                        Buildings = "Main",
                        Floors = "4",
                        Rooms = "7"
                    },

                    new Facility
                    {
                        People = "Kay",
                        Buildings = "Apt",
                        Floors = "L",
                        Rooms = "5A"
                    },

                    new Facility
                    {
                        People = "Cee",
                        Buildings = "University",
                        Floors = "32",
                        Rooms = "11"
                    },

                    new Facility
                    {
                        People = "Dee",
                        Buildings = "Company",
                        Floors = "C",
                        Rooms = "104"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
