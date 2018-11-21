﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace demosite.Models
{
    public class demositeContext : DbContext
    {
        public demositeContext (DbContextOptions<demositeContext> options)
            : base(options)
        {
        }
        
        public DbSet<demosite.Models.Facility> Facility { get; set; }
        public DbSet<demosite.Models.Person> Person { get; set; }
        public DbSet<demosite.Models.Building> Building { get; set; }
        public DbSet<demosite.Models.Floor> Floor { get; set; }
        public DbSet<demosite.Models.Room> Room { get; set; }
        // public DbSet<demosite.Models.PersonsBuilding> PersonsBuilding { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<PersonsBuilding>()
                .HasKey(pb => new { pb.PersonID, pb.BuildingID });

            modelbuilder.Entity<PersonsBuilding>()
                .HasOne(pb => pb.Person)
                .WithMany(p => p.PersonsBuildings)
                .HasForeignKey(pb => pb.PersonID);

            modelbuilder.Entity<PersonsBuilding>()
                .HasOne(pb => pb.Building)
                .WithMany(b => b.PersonsBuildings)
                .HasForeignKey(pb => pb.BuildingID);

            modelbuilder.Entity<Floor>()
                .HasOne(f => f.Building)
                .WithMany(b => b.Floors)
                .IsRequired();

            modelbuilder.Entity<Room>()
                .HasOne(r => r.Floor)
                .WithMany(f => f.Rooms)
                .IsRequired();
        }


    }
}