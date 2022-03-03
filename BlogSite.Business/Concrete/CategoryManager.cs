using BlogSite.Business.Abstract;
using BlogSite.DataAccess.Abstract;
using BlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category Add(Category entity)
        {
            return _categoryDal.Add(entity);
        }

        public Category Delete(int id)
        {
            var category = _categoryDal.GetById(id);
            return _categoryDal.Delete(category);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> predicate = null)
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public Category GetOne(Expression<Func<Category, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }
    }
}
