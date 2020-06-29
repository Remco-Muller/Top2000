using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Top2000.Models;

[assembly: OwinStartupAttribute(typeof(Top2000.Startup))]
namespace Top2000
{
    public partial class Startup
    {
        public async void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            await CreateDefaultRolesAsync();
        }
        private async System.Threading.Tasks.Task CreateDefaultRolesAsync()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Super Admin"))
            {
                // first we create SuperAdmin rol    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Super Admin";
                roleManager.Create(role);

                //Here we create a SuperAdmin user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "SuperAdmin@gmail.com";
                user.Email = "SuperAdmin@gmail.com";


                string userPWD = "Test123!!";

                var result = await UserManager.CreateAsync(user, userPWD);

                //Add default User to Role SuperAdmin    
                if (result.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Super Admin");

                }
            }
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

            }
        }
    }
}
