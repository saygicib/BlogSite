using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Business.Abstract
{
    public interface ICategoryService
    {
        CategoryGetDto GetById(int id);
        CategoryGetDto GetOne(Expression<Func<CategoryGetDto, bool>> predicate = null);
        List<CategoryGetDto> GetAll(Expression<Func<CategoryGetDto, bool>> predicate = null);
        void Add(CategoryAddDto entity);
        void Update(CategoryUpdateDto entity);
        void Delete(int id);
    }
}
