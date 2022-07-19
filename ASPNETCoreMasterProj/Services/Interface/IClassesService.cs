using DomainModels.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IClassesService
    {
        IEnumerable<ClassNameViewModel> GetAllIncludingStudents();
        Task<ClassNameViewModel> CreateUpdate(ClassNameViewModel className);
        IEnumerable<ClassNameViewModel> GetAll();
    }
}
