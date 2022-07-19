using DomainModels.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IStudentService
    {
        Task<StudentViewModel> CreateUpdate(StudentViewModel student);
        Task Delete(int id);
        IEnumerable<StudentViewModel> GetAll();
    }
}
