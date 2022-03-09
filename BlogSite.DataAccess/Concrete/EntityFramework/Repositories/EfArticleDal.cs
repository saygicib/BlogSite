using BlogSite.DataAccess.Abstract;
using BlogSite.DataAccess.Concrete.EntityFramework.Contexts;
using BlogSite.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfArticleDal : EfCoreGenericRepositoryDal<Article, BlogSiteContext>, IArticleDal
    {
        public List<Article> GetArticlesByCategoryId(Expression<Func<Article, bool>> predicate = null)
        {
            using (BlogSiteContext context= new BlogSiteContext())
            {
                var articleList = predicate == null
                    ? context.Set<Article>().Include(x => x.Category).ToList()
                    : context.Set<Article>().Include(x => x.Category).Where(predicate).ToList();
                return articleList;
            }
        }
        public List<Article> GetAllWithPagging(int page, int pageSize, Expression<Func<Article, bool>> predicate = null)
        {
            using (var context = new BlogSiteContext())
            {
                var articles = predicate == null
                    ? context.Set<Article>().Include(x => x.Category).Skip((page - 1) * pageSize).Take(pageSize).ToList()
                    : context.Set<Article>().Include(x => x.Category).Where(predicate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return articles;
            }
        }
    }
}
