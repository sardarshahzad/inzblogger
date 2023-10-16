using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogger.Models
{
    public class PostReaction
    {
        public int Id { get; set; }
        public ReactionType ReactionType { get; set; }
        public int ReactionTypeId { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
