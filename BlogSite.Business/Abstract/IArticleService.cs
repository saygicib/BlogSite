using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Business.Abstract
{
    public interface IArticleService
    {
        ArticleGetDto Get(int id);
        Article GetOne();
        List<Article> GetAll(); 
        void Add(ArticleAddDto entity);
        void Update(ArticleUpdateDto entity);
        void Delete(int id);
        List<Article> GetArticlesByCategoryId(int categoryId);
        ArticleGetDtoWithPagging GetAllWithPagging(int page, int pageSize);
        ArticleGetDtoWithPagging GetArticlesWithPaggingByCategoryId(int categoryId,int page, int pageSize);
        ArticleGetDtoWithPagging GetArticlesWithPaggingBySearchText(string searchText, int page, int pageSize);
        List<Article> GetArticlesByMostView();


    }
}
