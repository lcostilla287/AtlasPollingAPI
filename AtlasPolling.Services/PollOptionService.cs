using AtlasPolling.Data;
using AtlasPolling.Models.PollOptionModels;
using AtlasPollingAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasPolling.Services
{
    public class PollOptionService
    {
        private readonly Guid _userId;
        public PollOptionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePollOption(PollOptionCreate model)
        {
            var entity =
                new PollOption()
                {
                    CreatorId = _userId,
                    Description = model.Description,
                    PollId = model.PollId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PollOptions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PollOptionListItem> GetPollOptionsByPollId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .PollOptions
                    .Where(e => e.PollId == id)
                    .Select(
                        e =>
                        new PollOptionListItem
                        {
                           Description = e.Description
                        }
                        );
                return query.ToArray();
            }
        }
        public bool DeletePollOption(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PollOptions
                    .Single(e => e.Id == id && e.CreatorId == _userId);

                ctx.PollOptions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
