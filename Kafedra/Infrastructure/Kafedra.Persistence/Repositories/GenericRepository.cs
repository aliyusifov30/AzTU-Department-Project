using Kafedra.Application.Interfaces.Repostories;
using Kafedra.Domain.Entities.Common;
using Kafedra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Kafedra.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, IThisisEntity
    {
        private readonly KafedraContext _context;
        public GenericRepository(KafedraContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();


        public IQueryable<TEntity> GetAll()
            =>  Table;
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> exp)
        {
            return GetQuery().Where(exp);
        }

        public async Task<TEntity> GetByIdAsync( int id)
            => await Table.FindAsync(id);


        public Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            var query = GetQuery(includes);

            return query.Where(exp).ToListAsync();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes)
        {
            var query = GetQuery(includes);

            return await (query.FirstOrDefaultAsync(exp));
        }

        public async Task<bool> Create(TEntity entity)
        {
           var data= await Table.AddAsync(entity);
            return data.State== EntityState.Added;
        }

        public bool Update(TEntity entity)
        {
            var data = Table.Update(entity);
            return data.State==EntityState.Modified;    
        }

        public bool UnActive(TEntity entity)
        {
            if (entity.IsDeleted==true)
            {
                return entity.IsDeleted = false;

            }
            else
            {
                return entity.IsDeleted = true;

            }

        }

        public bool Delete(TEntity entity)
        {
            var data = Table.Remove(entity);
                return data.State==EntityState.Deleted;
        }
        public bool DeleteRange(List<TEntity> entitis)
        {
            Table.RemoveRange(entitis);
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
           TEntity data = await Table.FirstOrDefaultAsync(m=>m.Id==id);
          return Delete(data);
        }

        public async Task<int> Save()
            => await _context.SaveChangesAsync();
        
        private IQueryable<TEntity> GetQuery(params string[] includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query.Include(item);
                }
            }
            return query;
        }

    }
}
