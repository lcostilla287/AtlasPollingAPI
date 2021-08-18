using AtlasPolling.Data;
using AtlasPolling.Models.PollModels;
using AtlasPolling.Models.PollOptionModels;
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
        public IEnumerable<PollListItem> GetAllPolls()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Polls
                    .Select(
                        e =>
                        new PollListItem
                        {
                            Name = e.Name,
                            Description = e.Description
                        }
                        );
                return query.ToArray();
            }
        }
        public IEnumerable<PollListItem> GetYourPolls()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Polls
                    .Where(e => e.CreatorId == _userId)
                    .Select(
                        e =>
                        new PollListItem
                        {
                            Name = e.Name,
                            Description = e.Description
                        }
                        );
                return query.ToArray();
            }
        }
        public PollDetail GetPollById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Polls
                    .Single(e => e.Id == id);
                return
                    new PollDetail
                    {
                       Id = entity.Id,
                       Name = entity.Name,
                       Description = entity.Description,
                       CreatedUtc = entity.CreatedUtc,
                       CreatedBy = entity.CreatedBy,
                       PollEnd = entity.PollEnd,
                        Options = entity.Options
                        .Select(x => new PollOptionListItem()
                        {
                          Description = x.Description
                        }
                        ).ToList(),
                    };
            }
        }
        public bool UpdatePoll(PollEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Polls
                    .Single(e => e.Id == model.Id && e.CreatorId == _userId);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.PollEnd = model.PollEnd;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePoll(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Polls
                    .Single(e => e.Id == id && e.CreatorId == _userId);

                ctx.Polls.Remove(entity);

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
