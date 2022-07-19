using DomainModels.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IClassesRepositories
    {
        Task<ClassName> Add(ClassName entity);
        Task<ClassName> Update(ClassName entity);
        IQueryable<ClassName> GetAll();
        Task Delete(int id);
        IQueryable<ClassName> GetAllIncludingStudents();
    }
}
