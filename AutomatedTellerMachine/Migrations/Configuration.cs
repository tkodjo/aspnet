namespace AutomatedTellerMachine.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Services;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutomatedTellerMachine.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "AutomatedTellerMachine.Models.ApplicationDbContext";
        }

        protected override void Seed(AutomatedTellerMachine.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(t => t.UserName == "cadmin@mvcatm.com"))
            {
                var user = new ApplicationUser { UserName = "cadmin@mvcatm.com", Email = "cadmin@mvcatm.com" };
                userManager.Create(user,"passW0rd");

                var service = new CheckingAccountServices(context);
                service.CreateCheckingAccount("admin", "user", 1000, user.Id);

                //adding role
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }

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
            //

            //context.TransactionModels.Add(new TransactionModel { Amount = 44, CheckingAccountId = 4 });
            //context.TransactionModels.Add(new TransactionModel { Amount = -24, CheckingAccountId = 4 });
            //context.TransactionModels.Add(new TransactionModel { Amount = 40000, CheckingAccountId = 4 });
            //context.TransactionModels.Add(new TransactionModel { Amount = 49.9m, CheckingAccountId = 4 });
            //context.TransactionModels.Add(new TransactionModel { Amount = 64.40m, CheckingAccountId = 4 });
            //context.TransactionModels.Add(new TransactionModel { Amount = 400, CheckingAccountId = 4 });
            //context.TransactionModels.Add(new TransactionModel { Amount = -300, CheckingAccountId = 4 });
            //context.TransactionModels.Add(new TransactionModel { Amount = 244.44m, CheckingAccountId = 4 });
            //context.TransactionModels.Add(new TransactionModel { Amount = 498, CheckingAccountId = 4 });
            //context.TransactionModels.Add(new TransactionModel { Amount = 2, CheckingAccountId = 4 });
            //context.TransactionModels.Add(new TransactionModel { Amount = 40, CheckingAccountId = 4 });
        }
    }
}
