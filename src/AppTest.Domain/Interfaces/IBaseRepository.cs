using AppTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTest.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<bool> Exist(int id);
    }
}
