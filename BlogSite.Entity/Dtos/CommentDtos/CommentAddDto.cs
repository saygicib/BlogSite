using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Dtos.CommentDtos
{
    public class CommentAddDto
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string MainContent { get; set; }
    }
}
