using BlogSite.Business.Abstract;
using BlogSite.Entity.Concrete;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetCategories")]
        public ActionResult<List<Category>> GetCategories()
        {
            var categories = _categoryService.GetAll();
            if (categories == null)
            {
                return NotFound();
            }
            return categories;
        }
        [HttpGet("GetCategoryById")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }        
        [HttpPost("UpdateCategory")]
        public ActionResult<Category> UpdateCategory(Category article)
        {
            var updatedArticle = _categoryService.Add(article);
            if (updatedArticle == null)
            {
                return NotFound();
            }
            return updatedArticle;
        }
        [HttpPost("AddCategory")]
        public ActionResult<Category> AddCategory(Category article)
        {
            var addedArticle = _categoryService.Add(article);
            if (addedArticle == null)
            {
                return NotFound();
            }
            return addedArticle;
        }
        [HttpPost("DeleteCategory")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            var deleteArticle = _categoryService.Delete(id);
            if (deleteArticle == null)
            {
                return NotFound();
            }
            return deleteArticle;
        }
    }
}
