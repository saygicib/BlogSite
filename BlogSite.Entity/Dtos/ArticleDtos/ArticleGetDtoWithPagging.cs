using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Dtos.ArticleDtos
{
    public class ArticleGetDtoWithPagging
    {
        public List<ArticleGetDto> ArticleGetDtos { get; set; }
        public int TotalCount { get; set; }
    }
}
