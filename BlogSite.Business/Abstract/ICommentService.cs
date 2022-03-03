using BlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Business.Abstract
{
    public interface ICommentService
    {
        Comment GetById(int id);
        Comment GetOne(Expression<Func<Comment, bool>> predicate = null);
        List<Comment> GetAll(Expression<Func<Comment, bool>> predicate = null);
        Comment Add(Comment entity);
        Comment Update(Comment entity);
        Comment Delete(int id);
        List<Comment> GetCommentsByArticleId(int articleId);
    }
}
