namespace PMS.Repository.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PMS.Repository.PMSDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PMS.Repository.PMSDBContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new PMSDBContext()));

            var roleManager = new RoleManager<RoleMaster>(new RoleStore<RoleMaster>(new PMSDBContext()));

            var user = new ApplicationUser()
            {
                UserName = "SuperAdmin",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true,
                FirstName = "Super",
                LastName = "Admin",
                PhoneNumber = "9811228848",
                CreatedDate = DateTime.Now
            };

            manager.Create(user, "Bond@008");
            var adminUser = manager.FindByName("SuperAdmin");
            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new RoleMaster { Name = "SuperAdmin"});
                roleManager.Create(new RoleMaster { Name = "Author"});
                roleManager.Create(new RoleMaster { Name = "Learner"});
            }



            manager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Author","Learner" });
        }
    }
    
}
