using DomainModels.Entity;
using Microsoft.EntityFrameworkCore;
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

        public override async Task<ClassName> Add(ClassName entity)
        {            
            _dBContext.ClassNames.Add(entity);
            await _dBContext.SaveChangesAsync();
            return FindById(entity.Id);
        }

        public override async Task Delete(int id)
        {
            var items = FindById(id);
            _dBContext.Remove(items);
            await _dBContext.SaveChangesAsync();
        }

        public override IQueryable<ClassName> GetAll()
             => _dBContext.ClassNames;

        public override async Task<ClassName> Update(ClassName entity)
        {
            _dBContext.ClassNames.Update(entity);
            await _dBContext.SaveChangesAsync();
            return FindById(entity.Id);
        }

        public IQueryable<ClassName> GetAllIncludingStudents()
            => GetAll().Include(x => x.Students).OrderByDescending(s => s.SubjectName);

        public ClassName FindById(int id)
            => _dBContext.ClassNames.Find(id);
    }
}
