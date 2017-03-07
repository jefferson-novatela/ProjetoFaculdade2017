using ProjetoLucy.Domain.Interfaces.Reposi;
using ProjetoLucy.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucy.Infra.RepositoryBase
{
    public class RepositoryBase<TEntity> : IDisposable where TEntity : class
    {

        protected ProjetoLucyContext Db;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase()
        {
            Db = new ProjetoLucyContext();
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Add(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            SaveChanges();
            return objReturn;
        }

        public async Task<TEntity> AddAsync(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            await SaveChangesAsync();
            return objReturn;
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public virtual TEntity Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            SaveChanges();

            return obj;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            await SaveChangesAsync();

            return obj;
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
