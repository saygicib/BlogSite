using BlogSite.Business.Abstract;
using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.CategoryDtos;
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
        public ActionResult UpdateCategory(CategoryUpdateDto category)
        {
            _categoryService.Update(category);
            return Ok();
        }
        [HttpPost("AddCategory")]
        public ActionResult AddCategory(CategoryAddDto category)
        {
            _categoryService.Add(category);
            return Ok();
        }
        [HttpPost("DeleteCategory")]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}
