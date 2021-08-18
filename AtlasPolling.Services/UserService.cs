using AtlasPollingAPI.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasPolling.Services
{
    public class UserService
    {
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            using(var ctx = new ApplicationDbContext())
            {
                return ctx.Users.ToList();
            }
        }
        public IEnumerable<IdentityRole> GetAllRoles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Roles.ToList();
            }
        }
    }

    //var currentUserId = User.Identity.GetUserId();
    //var currentRoles = UserManager.GetRolles(CurrentUserId)
    //if (!CurrentRoles.Contains("admin")
    //ModelState.AddModelError("", "You don't have permission to do this")

    //if (UserIsAdmin && !model.IsAdmin)
    //if (userId == CurrentuserId)
    //ModelState.AddModelError("","You Can't remove yourself from Admin")
    //UserManager.RemoveFromRole(userId, "admin")
}
