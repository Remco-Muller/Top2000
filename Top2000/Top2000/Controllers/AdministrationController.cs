using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Top2000.Models;

    /* CONTROLLER:              AdministationController
     * MODEL:                   VmUsersList
     * Authorize Level:         Super Admin
     * 
     * RM - 2020
     */


namespace Top2000.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class AdministrationController : Controller
    {
        /*----------------------------------------------------------------------------------
         *Database connection that allows to communicate with the buildin Database
         * 
         * RM - 2020
         */
        public ApplicationDbContext context = new ApplicationDbContext();

        /*----------------------------------------------------------------------------------
         * PAGE:    Administration/CreateRole
         * TYPE:    GET
         * 
         * RM - 2020
         */

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }


        /*----------------------------------------------------------------------------------
         * PAGE:    Administration/CreateRole
         * TYPE:    POST
         * 
         * On post creates a role and stores it into the default databse using RoleManager,
         * and identity.
         * 
         * Checks if the role given does already exists.
         * 
         * Returns to home after success
         * 
         * RM - 2020
         */


        [HttpPost]
        public ActionResult CreateRole(VmCreateRole model)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                if (!roleManager.RoleExists(model.RoleName))
                {
                    IdentityRole identityRole = new IdentityRole
                    {
                        Name = model.RoleName
                    };
                    roleManager.Create(identityRole);
                }
               
                return RedirectToAction("index", "Home");

            }
            return View(model);
        }



        /* ------------------------------------------------------------------------------------
         * PAGE:    Administration/Index
         * TYPE:    GET
         * 
         * Lists out all users and check their roles.
         * Storing them into a list.
         * 
         * Creates a dropdown menu for all the avalible roles.
         * 
         * Returns a list of all users
         * 
         * RM 2020
         */

        [HttpGet]
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            List<VmUsersList> model = new List<VmUsersList>();
            foreach (var item in context.Users)
            {
                VmUsersList user = new VmUsersList()
                {
                    userId = item.Id,
                    UserName = item.UserName,
                    RoleUser = userManager.GetRoles(item.Id).Count() != 0 ? userManager.GetRoles(item.Id):null
                };
                model.Add(user);
            }
            ViewBag.RoleName = new SelectList(context.Roles, "Name", "Name");
            return View(model);
        }


        /* ---------------------------------------------------------------------------------
         * PAGE:    Administration/Index
         * TYPE:    POST
         * 
         * Adds/Deletes a role from/to a user,
         * Depending on the button pressed
         * 
         * Returns to Home/Index after success
         * 
         * RM - 2020
         */

        [HttpPost]
        public ActionResult Index(VmUsersList model)
        {
            if (ModelState.IsValid)
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                if (model.button == "Add role")
                {
                    UserManager.AddToRole(model.userId, model.RoleName);
                }else if (model.button == "Delete role")
                {
                    UserManager.RemoveFromRole(model.userId, model.RoleName);
                }
                
                
                
            }
            return RedirectToAction("Index", "Home");
        }
    }
}