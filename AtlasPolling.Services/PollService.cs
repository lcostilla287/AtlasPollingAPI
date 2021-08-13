using AtlasPolling.Data;
using AtlasPolling.Models.PollModels;
using AtlasPollingAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AtlasPolling.Services
{
    public class  PollService
    {
        private readonly Guid _userId;

        private readonly string _currentUserName = HttpContext.Current.User.Identity.Name;

        public PollService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePoll(PollCreate model)
        {
            var entity =
                new Poll()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now,
                    CreatorId = _userId,
                    CreatedBy = _currentUserName,
                    PollEnd = model.PollEnd
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Polls.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        //I used this in the past to check if admin. it may be useful 
        /* public bool UserIsAdmin(string userid)
         {

             ApplicationDbContext context = new ApplicationDbContext();
             var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

             var roles = UserManager.GetRoles(userid);

             if (roles.Contains("admin"))
             {

                 return true;
             }
             return false;


         }
     */
    }
}
