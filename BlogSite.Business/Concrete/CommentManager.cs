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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public Comment Add(Comment entity)
        {
            return _commentDal.Add(entity);
        }

        public Comment Delete(int id)
        {
            var category = _commentDal.GetById(id);
            return _commentDal.Delete(category);
        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>> predicate = null)
        {
            return _commentDal.GetAll();
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> GetCommentsByArticleId(int articleId)
        {
            return _commentDal.GetCommentsByArticleId(x => x.ArticleId == articleId);
        }

        public Comment GetOne(Expression<Func<Comment, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Comment Update(Comment entity)
        {
            return _commentDal.Update(entity);
        }
    }
}
