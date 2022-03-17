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

        public List<ArticleGetDto> GetArticlesByCategoryId(int categoryId)
        {

            var articles = _articleDal.GetArticlesByCategoryId(x => x.CategoryId == categoryId);
            var mappedArticles = _mapper.Map<List<ArticleGetDto>>(articles);
            return mappedArticles;
        }

        public ArticleGetDto Get(int id)
        {
            var article = _articleDal.Get(x => x.Id == id, x => x.Category);
            article.ViewCount += 1;
            _articleDal.Update(article);
            var mappedArticle = _mapper.Map<ArticleGetDto>(article);
            mappedArticle.CommentCount = _commentDal.Count(x => x.ArticleId == id);
            return mappedArticle;
        }

        public Article GetOne()
        {
            throw new NotImplementedException();
        }

        public void Update(ArticleUpdateDto dto)
        {
            var updateArticle = _mapper.Map<Article>(dto);
            _articleDal.Update(updateArticle);
        }
        public void Delete(int id)
        {
            var deleteArticle = _articleDal.GetById(id);
            _articleDal.Delete(deleteArticle);
        }

        public List<ArticleGetDto> GetAll()
        {
            var articles = _articleDal.GetAll();
            var mappedArticles = _mapper.Map<List<ArticleGetDto>>(articles);
            return mappedArticles;
        }

        public List<ArticleGetDto> GetArticlesByMostView()
        {
            var articles = _articleDal.GetByTakeNumber(10).OrderByDescending(x => x.ViewCount).ToList();
            var mapperArticles = _mapper.Map<List<ArticleGetDto>>(articles);
            return mapperArticles;
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

        public ArticleGetDtoWithPagging GetArticlesWithPaggingByCategoryId(int categoryId, int page, int pageSize)
        {
            var articles = _articleDal.GetAllWithPagging(page, pageSize, x => x.CategoryId == categoryId);
            var count = _articleDal.Count(x => x.CategoryId == categoryId);
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

        public ArticleGetDtoWithPagging GetArticlesWithPaggingBySearchText(string searchText, int page, int pageSize)
        {
            var articles = _articleDal.GetAllWithPagging(page, pageSize, x => x.Title.Contains(searchText));
            var count = _articleDal.Count(x => x.Title.Contains(searchText));
            var mappedArticle = _mapper.Map<List<ArticleGetDto>>(articles.OrderByDescending(x => x.CreatedDate));
            foreach (var item in mappedArticle)
            {
                item.CommentCount = _commentDal.Count(x => x.ArticleId == item.Id);
            }
            ArticleGetDtoWithPagging articleGetDtoWithPagging = new();
            articleGetDtoWithPagging.ArticleGetDtos = mappedArticle;
            articleGetDtoWithPagging.TotalCount = count;
            return articleGetDtoWithPagging;
        }

        public ArticleGetDtoWithPagging GetArticlesArchiveList(int year, int month, int page, int pageSize)
        {
            var articles = _articleDal.GetAllWithPagging(page, pageSize, x => x.CreatedDate.Year == year && x.CreatedDate.Month == month);
            var count = _articleDal.Count(x => x.CreatedDate.Year == year && x.CreatedDate.Month == month);
            var mappedArticles = _mapper.Map<List<ArticleGetDto>>(articles);
            ArticleGetDtoWithPagging articleGetDtoWithPagging = new ArticleGetDtoWithPagging
            {
                ArticleGetDtos=mappedArticles,
                TotalCount=count
            };
            return articleGetDtoWithPagging;
        }

        public object GetArticlesArchive()
        {
            var articles = _articleDal.GetArticlesArchiveGroupByDate();
            return articles;
        }

        
    }
}
