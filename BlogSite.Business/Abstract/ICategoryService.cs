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
        Category GetById(int id);
        Category GetOne(Expression<Func<Category, bool>> predicate = null);
        List<Category> GetAll(Expression<Func<Category, bool>> predicate = null);
        void Add(CategoryAddDto entity);
        void Update(CategoryUpdateDto entity);
        void Delete(int id);
    }
}
