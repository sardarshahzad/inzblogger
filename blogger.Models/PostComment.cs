using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogger.Models
{
    public class PostComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string CommentedOn { get; set; }
        public  Post Post { get; set; }
        public int PostId { get; set; }
    }
}
