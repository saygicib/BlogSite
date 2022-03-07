using BlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Abstract
{
    public interface IArticleDal : IRepositoryBaseDal<Article>
    {
        List<Article> GetArticlesByCategoryId(Expression<Func<Article, bool>> predicate = null);
        List<Article> GetAllWithPagging(int page, int pageSize);
    }
}
