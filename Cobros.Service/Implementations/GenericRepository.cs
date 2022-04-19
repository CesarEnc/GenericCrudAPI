using Cobros.Service.Intefaces;
using Cobros.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cobros.Service.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly CobrosDBContext _context;

        public GenericRepository(CobrosDBContext context) => _context = context;

        public async Task Add(T newT)
        {
            await _context.Set<T>().AddAsync(newT);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Modify(T newT)
        {
            _context.Set<T>().Update(newT);
            await _context.SaveChangesAsync();
        }

    }
}
