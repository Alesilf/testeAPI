using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Infra.Data.Context;
using Layer.Architecture.Infra.Data.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Layer.Architecture.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MyContext _myContext;

        public BaseRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<TEntity> Insert(TEntity obj)
        {
            var ret = _myContext.Set<TEntity>().Add(obj);
            _myContext.SaveChanges();
            return ret.Entity;

        }

        public async Task Update(TEntity obj)
        {
            _myContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _myContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            _myContext.Set<TEntity>().Remove(await Select(id));
            _myContext.SaveChanges();
        }

        public async Task<IList<TEntity>> Select() =>
            _myContext.Set<TEntity>().ToList();

        public async Task<TEntity> Select(int id) =>
            _myContext.Set<TEntity>().Find(id);

    }
}
