using BlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Abstract
{
    public interface ICommentDal : IRepositoryBaseDal<Comment>
    {
        List<Comment> GetCommentsByArticleId(Expression<Func<Comment, bool>> predicate = null);
    }
}
