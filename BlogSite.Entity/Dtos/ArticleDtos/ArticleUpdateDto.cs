using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Dtos.ArticleDtos
{
    public class ArticleUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentSummary { get; set; }
        public string MainContent { get; set; }
        public string ImageUrl { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int ViewCount { get; set; }
        public int CategoryId { get; set; }
    }
}
