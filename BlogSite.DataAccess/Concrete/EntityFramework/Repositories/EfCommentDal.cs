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
    public class EfCommentDal : EfCoreGenericRepositoryDal<Comment, BlogSiteContext>, ICommentDal
    {
        public List<Comment> GetCommentsByArticleId(Expression<Func<Comment, bool>> predicate = null)
        {
            using (BlogSiteContext context = new BlogSiteContext())
            {
                var commets = predicate == null
                    ? context.Set<Comment>().Include(x => x.Article).ToList()
                    : context.Set<Comment>().Include(x => x.Article).Where(predicate).ToList();
                return commets;
            }
        }
    }
}
