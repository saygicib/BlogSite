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

        [HttpGet]
        public ActionResult<List<CategoryGetDto>> GetCategory()
        {
            System.Threading.Thread.Sleep(500);
            var categories = _categoryService.GetAll();
            if (categories == null)
            {
                return NotFound();
            }
            return categories;
        }
        [HttpGet("{id}")]
        public ActionResult<CategoryGetDto> GetCategory(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }        
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id,CategoryUpdateDto category)
        {
            _categoryService.Update(category);
            return Ok();
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryAddDto category)
        {
            _categoryService.Add(category);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}
