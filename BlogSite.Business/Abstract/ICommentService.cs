using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.CommentDtos;
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
        void Add(CommentAddDto dto);
        void Update(CommentUpdateDto dto);
        void Delete(int id);
        List<Comment> GetCommentsByArticleId(int articleId);
    }
}
