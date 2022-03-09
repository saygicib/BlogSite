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
        [HttpGet]
        public ActionResult<List<Article>> GetArticles()
        {
            var articles = _articleService.GetAll();
            if (articles == null)
            {
                return NotFound();
            }
            return articles;
        }


        [HttpGet("{page}/{pageSize}")]
        public IActionResult GetArticles(int page=1,int pageSize=5)
        {
            System.Threading.Thread.Sleep(500);
            var articles = _articleService.GetAllWithPagging(page, pageSize);
            return Ok(articles);
        }



        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
        public ActionResult UpdateArticle(int id,ArticleUpdateDto dto)
        {
            _articleService.Update(dto);
            return Ok();
        }
        [HttpPost]
        public ActionResult AddArticle(ArticleAddDto dto)
        {
            _articleService.Add(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            _articleService.Delete(id);
            return Ok();
        }
    }
}
