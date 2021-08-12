using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasPolling.Data
{
    public class Poll

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTimeOffset CreatedUTC { get; set; }

        public string CreatedBy { get; set; }

        public DateTime PollEnd { get; set; }

        public virtual List<PollOption> Options { get; set; } = new List<PollOption>();
    }

}
