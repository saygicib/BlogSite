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
        private IMapper _mapper;
        public ArticleManager(IArticleDal articleDal, IMapper mapper)
        {
            _articleDal = articleDal;
            _mapper = mapper;
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

        public ArticleGetDtoWithPagging GetAllWithPagging(int page, int pageSize)
        {
            var articles = _articleDal.GetAllWithPagging(page, pageSize);
            var count = _articleDal.GetAll().Count();
            var mappedArticle = _mapper.Map<List<ArticleGetDto>>(articles);
            ArticleGetDtoWithPagging articleGetDtoWithPagging = new();
            articleGetDtoWithPagging.ArticleGetDtos = mappedArticle;
            articleGetDtoWithPagging.TotalCount = count;
            return articleGetDtoWithPagging;
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

        public void Update(ArticleUpdateDto dto)
        {
            var updateArticle = _mapper.Map<Article>(dto);
            _articleDal.Update(updateArticle);
        }
    }
}
