using DomainModels.Entity;
using Microsoft.Extensions.Logging;
using Repositories.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class ClassesRepositories : GenericRepository<ClassName>, IClassesRepositories
    {
        public ClassesRepositories(ILogger<ClassName> logger, AppDBContext dBContext) : base(logger, dBContext)
        {
        }

        public override Task<ClassName> Add(ClassName entity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<ClassName> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<ClassName> Update(ClassName entity)
        {
            throw new NotImplementedException();
        }
    }
}
