using Cobros.Service.MicroModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cobros.Service.Intefaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> GetById(int id);
        public Task Add(TEntity newT);
        public Task Modify(TEntity newT);
        public Task Delete(int id);
    }
}
