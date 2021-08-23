using AtlasPolling.Models.PollModels;
using AtlasPolling.Services;
using AtlasPollingAPI.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AtlasPollingAPI.Controllers
{
    public class PollController : ApiController
    {
        private PollService CreatePollService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var pollService = new PollService(userId);
            return pollService;
        }

        
        //POST
        public IHttpActionResult Post(PollCreate model)
        {
            //I Believe this is what we need
            if (!User.IsInRole("admin"))
                return BadRequest("You do not have permission to do this");
            //

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePollService();

            if (!service.CreatePoll(model))
                return InternalServerError();

            return Ok();
        }
    }
}
