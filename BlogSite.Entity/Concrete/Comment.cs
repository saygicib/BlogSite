using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Concrete
{
    public class Comment
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string MainContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public Article Article { get; set; }
    }
}
