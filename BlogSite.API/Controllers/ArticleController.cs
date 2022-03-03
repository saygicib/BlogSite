using BlogSite.Business.Abstract;
using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet("GetArticles")]
        public ActionResult<List<Article>> GetArticles()
        {
            var articles = _articleService.GetAll();
            if (articles == null)
            {
                return NotFound();
            }
            return articles;
        }
        [HttpGet("GetArictleById")]
        public ActionResult<Article> GetArticle(int id)
        {
            var article = _articleService.GetById(id);
            if (article == null)
            {
                return NotFound();
            }
            return article;
        }
        [HttpGet("GetArticlesByCategoryId")]
        public ActionResult<List<Article>> GetArticles(int categoryId)
        {
            var articles = _articleService.GetArticlesByCategoryId(categoryId);
            if (articles == null)
            {
                return NotFound();
            }
            return articles;
        }
        [HttpPost("UpdateArticle")]
        public ActionResult UpdateArticle(ArticleUpdateDto dto)
        {
            _articleService.Update(dto);
            return Ok();
        }
        [HttpPost("AddArticle")]
        public ActionResult AddArticle(ArticleAddDto dto)
        {
            _articleService.Add(dto);
            return Ok();
        }
        [HttpPost("DeleteArticle")]
        public ActionResult DeleteArticle(int id)
        {
            _articleService.Delete(id);
            return Ok();
        }
    }
}
