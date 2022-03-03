using AutoMapper;
using BlogSite.Business.Abstract;
using BlogSite.DataAccess.Abstract;
using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.CommentDtos;
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
        private IMapper _mapper;
        public CommentManager(ICommentDal commentDal, IMapper mapper)
        {
            _commentDal = commentDal;
            _mapper = mapper;
        }

        public void Add(CommentAddDto dto)
        {
            var addComment = _mapper.Map<Comment>(dto);
            _commentDal.Add(addComment);
        }

        public void Delete(int id)
        {
            var category = _commentDal.GetById(id);
            _commentDal.Delete(category);
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

        public void Update(CommentUpdateDto dto)
        {
            var updateComment = _mapper.Map<Comment>(dto);
            _commentDal.Update(updateComment);
        }
    }
}
