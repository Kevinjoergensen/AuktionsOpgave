namespace AuktionsOpgave.Migrations
{
    using AuktionsOpgave.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuktionsOpgave.Storage.AuctionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AuktionsOpgave.Storage.AuctionContext context)
        {

            context.People.AddOrUpdate(s => s.Id, new Person { Id = 1, Name = "Preben Lauritsen", Password = "1234", Email = "plau@gmail.com", Telnr = "45151553" });
            context.People.AddOrUpdate(s => s.Id, new Person { Id = 2, Name = "Göran Olsson", Password = "1234", Email = "gol@gmail.com", Telnr = "154522653" });
            context.People.AddOrUpdate(s => s.Id, new Person { Id = 3, Name = "Charles Hemmington", Password = "1234", Email = "ch@gmail.com", Telnr = "555424235" });
            context.People.AddOrUpdate(s => s.Id, new Person { Id = 4, Name = "Al-Waleed Bin Talal", Password = "1234", Email = "sheik@gmail.com", Telnr = "252545875" });
            context.People.AddOrUpdate(s => s.Id, new Person { Id = 5, Name = "Folorunso Alakija", Password = "1234", Email = "fa@gmail.com", Telnr = "24445875" });
            context.People.AddOrUpdate(s => s.Id, new Person { Id = 6, Name = "Ursula Klatten", Password = "1234", Email = "uk@gmail.com", Telnr = "11515445" });
            context.Items.AddOrUpdate(i => i.Id, new Item { Id = 1, Type = Models.Type.Gold, Amount = 230, Price = 50000, Expire = new DateTime(2020, 6, 10, 10, 30, 0), Buyer = context.People.Where(p => p.Id.Equals(1)).First(), Seller = context.People.Where(s => s.Id.Equals(6)).First() });
            context.Items.AddOrUpdate(i => i.Id, new Item { Id = 2, Type = Models.Type.Gold, Amount = 230, Price = 50000, Expire = new DateTime(2020, 5, 25, 12, 0, 0), Buyer = context.People.Where(p => p.Id.Equals(5)).First(), Seller = context.People.Where(s => s.Id.Equals(1)).First() });
            context.Items.AddOrUpdate(i => i.Id, new Item { Id = 3, Type = Models.Type.Silver, Amount = 23, Price = 10000, Expire = new DateTime(2020, 5, 25, 12, 0, 0), Buyer = context.People.Where(p => p.Id.Equals(4)).First(), Seller = context.People.Where(s => s.Id.Equals(1)).First() });
            context.Items.AddOrUpdate(i => i.Id, new Item { Id = 4, Type = Models.Type.Silver, Amount = 20, Price = 5000, Expire = new DateTime(2020, 5, 30, 12, 0, 0), Buyer = context.People.Where(p => p.Id.Equals(6)).First(), Seller = context.People.Where(s => s.Id.Equals(3)).First() });
            context.Items.AddOrUpdate(i => i.Id, new Item { Id = 5, Type = Models.Type.Platinum, Amount = 440, Price = 150000, Expire = new DateTime(2020, 5, 21, 18, 30, 0), Seller = context.People.Where(s => s.Id.Equals(2)).First() });
            context.Items.AddOrUpdate(i => i.Id, new Item { Id = 6, Type = Models.Type.Titanium, Amount = 23, Price = 10000, Expire = new DateTime(2020, 5, 22, 14, 0, 0), Seller = context.People.Where(s => s.Id.Equals(2)).First() });
            context.Items.AddOrUpdate(i => i.Id, new Item { Id = 7, Type = Models.Type.Titanium, Amount = 20, Price = 8000, Expire = new DateTime(2020, 5, 18, 14, 0, 0), Seller = context.People.Where(s => s.Id.Equals(4)).First() });
            context.Items.AddOrUpdate(i => i.Id, new Item { Id = 8, Type = Models.Type.Palladium, Amount = 20, Price = 8000, Buyer = context.People.Where(p => p.Id.Equals(2)).First(), Expire = new DateTime(2020, 5, 19, 15, 40, 0), Seller = context.People.Where(s => s.Id.Equals(1)).First() });
            context.Items.AddOrUpdate(i => i.Id, new Item { Id = 9, Type = Models.Type.Palladium, Amount = 20, Price = 8000, Expire = new DateTime(2020, 5, 19, 15, 50, 0), Seller = context.People.Where(s => s.Id.Equals(5)).First() });
            context.Items.AddOrUpdate(i => i.Id, new Item { Id = 10, Type = Models.Type.Gold, Amount = 20, Price = 3000, Expire = new DateTime(2020, 5, 19, 16, 0, 0), Buyer = context.People.Where(p => p.Id.Equals(4)).First(), Seller = context.People.Where(s => s.Id.Equals(3)).First() });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
