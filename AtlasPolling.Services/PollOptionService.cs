using AtlasPolling.Data;
using AtlasPolling.Models.PollOptionModels;
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
                    Description = model.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tickets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
