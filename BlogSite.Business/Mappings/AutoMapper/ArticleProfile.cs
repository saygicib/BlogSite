using AutoMapper;
using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Business.Mappings.AutoMapper
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto, Article>();
            CreateMap<ArticleUpdateDto, Article>();
            CreateMap<Article, ArticleGetDto>();
        }
    }
}
