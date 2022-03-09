using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Abstract
{
    public interface IRepositoryBaseDal<TEntity>
    {
        TEntity GetById(int id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetOne(Expression<Func<TEntity, bool>> predicate = null);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }

}
