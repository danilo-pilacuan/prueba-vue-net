using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VentaEntradas.Domain.Contracts;

namespace VentaEntradas.Infraestructure.Repositories
{
    public class VentaEntradasRepository<TEntity, TEntityId> : IRepository<TEntity, TEntityId> where TEntity : class where TEntityId : struct
    {
        protected readonly VentaEntradasDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public VentaEntradasRepository(VentaEntradasDbContext context)
        {
            _context = context;
        }



        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public bool Delete(TEntity entity)
        {
            if (_context.Set<TEntity>().Remove(entity) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            //return true;
        }

        public IQueryable<TEntity> GetAllAsync()
        {
                return _context.Set<TEntity>().AsQueryable();
        }


        public async Task<TEntity> GetByIdAsync(TEntityId id)
        {
            return await _context.Set<TEntity>().FindAsync(id);

        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);

            return;
        }
    }
}
