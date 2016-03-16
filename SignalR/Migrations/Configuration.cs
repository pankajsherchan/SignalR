namespace SignalR.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SignalR.Models.SignalRContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SignalR.Models.SignalRContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            context.Employees.AddOrUpdate(
            e => e.Name,
         new Employee { Name = "Jim Wang", Email = "jim.wang@microsoft.com", Salary = 1 },
         new Employee { Name = "Kiran Challa", Email = "kiranchalla@microsoft.com", Salary = 1 },
         new Employee { Name = "Steve Sanderson", Email = "stevesanderson@microsoft.com", Salary = 1 }
       );



        }
    }
}
