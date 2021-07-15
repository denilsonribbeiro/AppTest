using AppTest.Domain.Entities;
using AppTest.Domain.Interfaces;
using AppTest.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTest.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly AppTestContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppTestContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entidade não foi informada.");

            var entityForAdd = await _dbSet.AddAsync(entity);
            _context.SaveChanges();

            return entityForAdd.Entity;
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entidade não foi informada");

            if (await Exist(entity.Id) == false)
                throw new ArgumentException("Entidade informada não existe");

            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entidade não foi informada");

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Exist(int id)
        {
            return await _dbSet.AsNoTracking().AnyAsync(x => Equals(x.Id, id));
        }

    }
}
