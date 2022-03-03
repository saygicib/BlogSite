using BlogSite.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Abstract
{
    public interface ICategoryDal : IRepositoryBaseDal<Category>
    {
    }
}
