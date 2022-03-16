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

        [HttpPut("{id}")]
        public ActionResult UpdateArticle(int id, ArticleUpdateDto dto)
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
        [HttpGet("GetArticlesByMostView")]
        public ActionResult<List<Article>> GetArticlesByMostView()
        {
            var articles = _articleService.GetArticlesByMostView();
            if (articles == null)
            {
                return NotFound();
            }
            return articles;
        }

        [HttpGet("{page}/{pageSize}")]
        public IActionResult GetArticles(int page=1,int pageSize=5)
        {
            System.Threading.Thread.Sleep(1500);
            var articles = _articleService.GetAllWithPagging(page, pageSize);
            return Ok(articles);
        }



        [HttpGet("{id}")]
        public ActionResult<ArticleGetDto> GetArticle(int id)
        {
            System.Threading.Thread.Sleep(1500);
            var article = _articleService.Get(id);
            if (article == null)
            {
                return NotFound();
            }
            return article;
        }
        [HttpGet("GetArticlesByCategoryId/{categoryId}/{page}/{pageSize}")]
        public IActionResult GetArticles(int categoryId, int page = 1, int pageSize = 5)
        {
            System.Threading.Thread.Sleep(1500);
            var articles = _articleService.GetArticlesWithPaggingByCategoryId(categoryId,page,pageSize);
            if (articles == null)
            {
                return NotFound();
            }
            return Ok(articles);
        }
        [HttpGet("GetArticlesBySearchText/{searchText}/{page}/{pageSize}")]
        public IActionResult SearchArticles(string searchText, int page = 1, int pageSize = 5)
        {
            System.Threading.Thread.Sleep(1500);
            var articles = _articleService.GetArticlesWithPaggingBySearchText(searchText, page, pageSize);
            if (articles == null)
            {
                return NotFound();
            }
            return Ok(articles);
        }      
    }
}
