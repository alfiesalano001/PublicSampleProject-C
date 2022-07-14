using DomainModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IStudentRepositories
    {
        Task<Student> Add(Student entity);
        Task<Student> Update(Student entity);
        Student FindById(int id);
        IQueryable<Student> GetAll();
        Task Delete(int id);
    }
}
