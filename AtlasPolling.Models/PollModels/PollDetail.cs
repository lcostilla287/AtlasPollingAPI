using AtlasPolling.Models.PollOptionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasPolling.Models.PollModels
{
    public class PollDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public string Description { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

      
      
        public string CreatedBy { get; set; }

        public DateTime PollEnd { get; set; }

        public virtual List<PollOptionListItem> Options { get; set; } = new List<PollOptionListItem>();
    }
}
