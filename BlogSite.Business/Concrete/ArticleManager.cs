using BlogSite.Business.Abstract;
using BlogSite.DataAccess.Abstract;
using BlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public Article Add(Article entity)
        {
            return _articleDal.Add(entity);
        }

        public Article Delete(int id)
        {
            var article = _articleDal.GetById(id);
            return _articleDal.Delete(article);
        }

        public List<Article> GetAll(Expression<Func<Article, bool>> predicate = null)
        {
            return _articleDal.GetAll();
        }

        public List<Article> GetArticlesByCategoryId(int categoryId)
        {
            return _articleDal.GetArticlesByCategoryId(x => x.CategoryId == categoryId);
        }

        public Article GetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public Article GetOne(Expression<Func<Article, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Article Update(Article entity)
        {
            return _articleDal.Update(entity);
        }
    }
}
