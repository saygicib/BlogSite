using AutoMapper;
using BlogSite.Business.Abstract;
using BlogSite.DataAccess.Abstract;
using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.CategoryDtos;
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
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public void Add(CategoryAddDto dto)
        {
            var addCategory = _mapper.Map<Category>(dto);
            _categoryDal.Add(addCategory);
        }

        public void Delete(int id)
        {
            var category = _categoryDal.GetById(id);
            _categoryDal.Delete(category);
        }

        public List<CategoryGetDto> GetAll(Expression<Func<CategoryGetDto, bool>> predicate = null)
        {
            var categories = _categoryDal.GetAll();
            var mappedCategories = _mapper.Map<List<CategoryGetDto>>(categories);
            return mappedCategories;
        }

        public CategoryGetDto GetById(int id)
        {
            var category = _categoryDal.GetById(id);
            var mappedCategory = _mapper.Map<CategoryGetDto>(category);
            return mappedCategory;
        }

        public CategoryGetDto GetOne(Expression<Func<CategoryGetDto, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryUpdateDto dto)
        {
            var updateCategory = _mapper.Map<Category>(dto);
            _categoryDal.Update(updateCategory);
        }
    }
}
