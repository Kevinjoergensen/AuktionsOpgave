using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AuktionsOpgave.Models;

namespace AuktionsOpgave.Storage
{
    public class AuctionContext : DbContext
    {
        public AuctionContext() : base("name=AuctionDb")
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Item> Items { get; set; }


    }
}