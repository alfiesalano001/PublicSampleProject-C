using DomainModels.Entity;
using Microsoft.Extensions.Logging;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudentRepositories : GenericRepository<Student>, IStudentRepositories
    {
        public StudentRepositories(ILogger<Student> logger, AppDBContext dBContext) : base(logger, dBContext)
        {
        }

        public override IQueryable<Student> GetAll()
            => _dBContext.Students;

        public override async Task<Student> Add(Student entity)
        {
            _dBContext.Students.Add(entity);
            await _dBContext.SaveChangesAsync();
            return FindById(entity.Id);
        }

        public override async Task Delete(int id)
        {
            var items = FindById(id);
            _dBContext.Remove(items);
            await _dBContext.SaveChangesAsync();
        }

        public override async Task<Student> Update(Student entity)
        {
            _dBContext.Students.Update(entity);
            await _dBContext.SaveChangesAsync();
            return FindById(entity.Id);
        }

        public Student FindById(int id)
            => _dBContext.Students.Find(id);
    }
}
