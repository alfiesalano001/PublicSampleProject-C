using DomainModels.Entity;
using Microsoft.Extensions.Logging;
using Repositories.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class GenericRepository<TEntity>
        where TEntity : EntityBase
    {
        protected readonly ILogger<TEntity> _logger;
        protected readonly AppDBContext _dBContext;
        protected GenericRepository(ILogger<TEntity> logger, AppDBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        public abstract Task<TEntity> Add(TEntity entity);
        public abstract Task<TEntity> Update(TEntity entity);
        public abstract Task Delete(int id);
        public abstract IQueryable<TEntity> GetAll();
    }
}
