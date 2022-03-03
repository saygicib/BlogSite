using BlogSite.DataAccess.Abstract;
using BlogSite.DataAccess.Concrete.EntityFramework.Contexts;
using BlogSite.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCategoryDal : EfCoreGenericRepositoryDal<Category, BlogSiteContext>, ICategoryDal
    {
    }
}
