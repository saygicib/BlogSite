﻿using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Business.Abstract
{
    public interface IArticleService
    {
        Article GetById(int id);
        Article GetOne(Expression<Func<Article, bool>> predicate = null);
        List<Article> GetAll(Expression<Func<Article, bool>> predicate = null);
        void Add(ArticleAddDto entity);
        void Update(ArticleUpdateDto entity);
        void Delete(int id);
        List<Article> GetArticlesByCategoryId(int categoryId);
    }
}
