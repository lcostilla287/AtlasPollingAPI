using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasPolling.Data
{
    public class PollOption
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        public List<string> Votes { get; set; } = new List<string>();

        public int VoteCount
        {
            get
            {
                int voteCount = Votes.Count;
                return voteCount;
            }

        }
        [Required]
        public Guid CreatorId { get; set; }

        [ForeignKey(nameof(Poll))]
        public int PollId { get; set; }
        public virtual Poll Poll { get; set; }
    }

}
