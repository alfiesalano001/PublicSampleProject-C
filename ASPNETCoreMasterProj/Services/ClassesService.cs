using AutoMapper;
using DomainModels.BindingModels;
using Microsoft.Extensions.Logging;
using Services.Interface;
using System.Threading.Tasks;

namespace Services
{
    public class ClassesService : ServiceBase<ClassesService>, IClassesService
    {
        public ClassesService(IMapper mapper, ILogger<ClassesService> logger)
          : base(mapper, logger)
        {

        }

        public async Task<ClassNameViewModel> CreateUpdate(ClassNameViewModel className)
        {
            var map = _mapper.Map<ClassNameViewModel>(className);
            //var result = _studentRepo.GetAll().FirstOrDefault(a => a.LastName == student.LastName && a.ClassNameId == student.ClassNameId);

            //if (result != null)
            //{
            //    result.Age = student.Age;
            //    result.GPA = student.GPA;
            //    result = await _studentRepo.Update(result);
            //}
            //else
            //    result = await _studentRepo.Add(map);

            //var toReturn = _mapper.Map<StudentViewModel>(result);
            //return toReturn;
            return null;
        }
    }
}
