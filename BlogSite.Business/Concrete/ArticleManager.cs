using AutoMapper;
using BlogSite.Business.Abstract;
using BlogSite.DataAccess.Abstract;
using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.ArticleDtos;
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
        private readonly ICommentDal _commentDal;
        private IMapper _mapper;
        public ArticleManager(IArticleDal articleDal, IMapper mapper, ICommentDal commentDal)
        {
            _articleDal = articleDal;
            _mapper = mapper;
            _commentDal = commentDal;
        }

        public void Add(ArticleAddDto dto)
        {
            var addArticle = _mapper.Map<Article>(dto);
            _articleDal.Add(addArticle);
        }

        public void Delete(int id)
        {
            var deleteArticle = _articleDal.GetById(id);
            _articleDal.Delete(deleteArticle);
        }

        public List<Article> GetAll(Expression<Func<Article, bool>> predicate = null)
        {
            return _articleDal.GetAll();
        }
        public ArticleGetDtoWithPagging GetArticlesWithPaggingByCategoryId(int categoryId,int page, int pageSize)
        {
            var articles = _articleDal.GetAllWithPagging(page, pageSize,x=>x.CategoryId==categoryId);
            var count = _articleDal.Count(x=>x.CategoryId==categoryId);
            var mappedArticle = _mapper.Map<List<ArticleGetDto>>(articles);
            foreach (var item in mappedArticle)
            {
                item.CommentCount = _commentDal.Count(x => x.ArticleId == item.Id);
            }
            ArticleGetDtoWithPagging articleGetDtoWithPagging = new();
            articleGetDtoWithPagging.ArticleGetDtos = mappedArticle;
            articleGetDtoWithPagging.TotalCount = count;
            return articleGetDtoWithPagging;
        }
        public ArticleGetDtoWithPagging GetAllWithPagging(int page, int pageSize)
        {
            var articles = _articleDal.GetAllWithPagging(page, pageSize);
            var count = _articleDal.GetAll().Count();
            var mappedArticle = _mapper.Map<List<ArticleGetDto>>(articles);
            foreach (var item in mappedArticle)
            {
                item.CommentCount = _commentDal.Count(x => x.ArticleId == item.Id);
            }
            ArticleGetDtoWithPagging articleGetDtoWithPagging = new();
            articleGetDtoWithPagging.ArticleGetDtos = mappedArticle;
            articleGetDtoWithPagging.TotalCount = count;
            return articleGetDtoWithPagging;
        }

        public List<Article> GetArticlesByCategoryId(int categoryId)
        {
            return _articleDal.GetArticlesByCategoryId(x => x.CategoryId == categoryId);
        }

        public ArticleGetDto Get(int id)
        {
            var article = _articleDal.Get(x => x.Id == id, x => x.Category);
            var mappedArticle = _mapper.Map<ArticleGetDto>(article);
            mappedArticle.CommentCount = _commentDal.Count(x => x.ArticleId == id);
            return mappedArticle;
        }

        public Article GetOne(Expression<Func<Article, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void Update(ArticleUpdateDto dto)
        {
            var updateArticle = _mapper.Map<Article>(dto);
            _articleDal.Update(updateArticle);
        }
    }
}
