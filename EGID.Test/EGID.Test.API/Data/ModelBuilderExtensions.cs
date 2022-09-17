using EGID.Test.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EGID.Test.API.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var rand=new Random();
            // Seed Data
            #region Seeding Stock Data
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 1, Name = "Vianet", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 2, Name = "Agritek", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 3, Name = "Akamai", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 4, Name = "Baidu" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 5, Name = "Blinkx" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 6, Name = "Blucora" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 7, Name = "Boingo" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 8, Name = "Brainybrawn" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 9, Name = "Carbonite" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 10, Name = "China Finance" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 11, Name = "ChinaCache" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 12, Name = "ADR" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 13, Name = "ChitrChatr" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 14, Name = "Cnova", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 15, Name = "Cogent" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 16, Name = "Crexendo" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 17, Name = "CrowdGather" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 18, Name = "EarthLink", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 19, Name = "Eastern" ,Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 20, Name = "ENDEXX" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 21, Name = "Envestnet" , Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID = 22, Name = "Epazz", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID =23, Name = "FlashZero", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID =24, Name = "Genesis", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID =25, Name = "InterNAP", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID =26, Name = "MeetMe", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID =27, Name = "Netease", Price = rand.Next(50, 101) });
            modelBuilder.Entity<Stock>().HasData(new Stock { ID =28, Name = "Qihoo", Price = rand.Next(50, 101) });
            #endregion

            #region Broker
            modelBuilder.Entity<Broker>().HasData(new Broker
            {
                ID = 1,
                Name = "Broker1"
            });
            #endregion
            #region Clients
            modelBuilder.Entity<Person>().HasData(new Person
            {
                ID = 1,
                Name = "Client1",
                BrokerId=1
            });

            modelBuilder.Entity<Person>().HasData(new Person
            {
                ID = 2,
                Name = "Client2",
                BrokerId=1
            });
            #endregion

            
        }
    }
}
