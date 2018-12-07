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
                if (context.Person.Any())
                {
                    return;
                }
                var buildings = new Building[]
               {
                    new Building
                    {
                        BName = "Library",
                        BAddress = "000 Avenue Street",
                        BuildingID = 1
                    },
                    new Building
                    {
                        BName = "Main",
                        BAddress ="555 Broadway",
                        BuildingID = 3
                    },
                    new Building
                    {
                        BName = "Office",
                        BAddress = "123 Court St",
                        BuildingID = 4
                    }
               };
                foreach (Building b in buildings)
                {
                    context.Building.Add(b);
                }
                context.SaveChanges();

                var people = new Person[]
                {
                    new Person
                    {
                        Fname = "Jay",
                        LName = "Kay",
                        PersonID = 1
                    },
                    new Person
                    {
                       Fname = "Bee",
                       LName = "Cee",
                       PersonID = 2
                    },
                    new Person
                    {
                       Fname = "May",
                       LName = "Ray",
                       PersonID = 3
                    }
                };
                foreach (Person p in people)
                {
                    context.Person.Add(p);
                }
                context.SaveChanges();

                var floors = new Floor[]
                {
                    new Floor
                    {
                        FloorName = "L",
                        FloorID = 2,
                        BuildingID = buildings.Single(b => b.BuildingID == 1).BuildingID
                    },
                    new Floor
                    {
                        FloorName = "14",
                        FloorID = 4,
                        BuildingID = buildings.Single(b => b.BuildingID == 3).BuildingID
                    },
                    new Floor
                    {
                        FloorName = "C",
                        FloorID = 6,
                        BuildingID = buildings.Single(b => b.BuildingID == 4).BuildingID
                    }
                };
                foreach (Floor f in floors)
                {
                    context.Floor.Add(f);
                }
                context.SaveChanges();
                var rooms = new Room[]
                {
                    new Room
                    {
                        RoomName = "2",
                        RoomID = 10,
                        FloorID = floors.Single(f => f.FloorID == 2).FloorID
 
                    },
                    new Room
                    {
                        RoomName = "Conference A",
                        RoomID = 11,
                        FloorID = floors.Single(f => f.FloorID == 4).FloorID
                    },
                    new Room
                    {
                        RoomName = "4106",
                        RoomID = 12,
                        FloorID = floors.Single(f => f.FloorID == 6).FloorID
                    }
                };
                foreach (Room r in rooms)
                {
                    context.Room.Add(r);
                }
                context.SaveChanges();

                var personsbuildings = new PersonsBuilding[]
                {
                    new PersonsBuilding
                    {
                        PersonID = people.Single(p => p.PersonID == 1).PersonID,
                        BuildingID = buildings.Single(b => b.BuildingID == 1).BuildingID,
                    },
                    new PersonsBuilding
                    {
                        PersonID = people.Single(p => p.PersonID == 2).PersonID,
                        BuildingID = buildings.Single(b => b.BuildingID == 3).BuildingID,
                    },
                    new PersonsBuilding
                    {
                        PersonID = people.Single(p => p.PersonID == 3).PersonID,
                        BuildingID = buildings.Single(b => b.BuildingID == 4).BuildingID,
                    }
                };
                foreach (PersonsBuilding pb in personsbuildings)
                {
                    var personsbuildingInDatabase = context.PersonsBuilding.Where(
                        p =>
                                p.Person.PersonID == pb.PersonID &&
                                p.Building.BuildingID == pb.PersonID).SingleOrDefault();
                    if (personsbuildingInDatabase == null) {
                        context.PersonsBuilding.Add(pb);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
     
