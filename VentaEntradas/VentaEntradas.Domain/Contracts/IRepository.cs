using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaEntradas.Domain.Contracts
{
    public interface IRepository <TEntity,TEntityId> 
        where TEntity : class
        where TEntityId : struct
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<TEntity> GetAllAsync();
        

        Task<TEntity> GetByIdAsync(TEntityId entityId);

        

        Task<TEntity> CreateAsync(TEntity entity);
        
        Task UpdateAsync(TEntity entity);
        
        
        bool Delete(TEntity entity); 

    }
}
