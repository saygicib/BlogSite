using BlogSite.Entities.Concrete;
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
        Category Add(Category entity);
        Category Update(Category entity);
        Category Delete(int id);
    }
}
