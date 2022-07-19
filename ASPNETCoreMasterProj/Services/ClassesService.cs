using AutoMapper;
using DomainModels.BindingModels;
using DomainModels.Entity;
using Microsoft.Extensions.Logging;
using Services.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ClassesService : ServiceBase<ClassesService>, IClassesService
    {
        private readonly Repositories.Interface.IClassesRepositories _classesRepo;

        public ClassesService(IMapper mapper, ILogger<ClassesService> logger, Repositories.Interface.IClassesRepositories classesRepositories)
          : base(mapper, logger)
        {
            _classesRepo = classesRepositories;
        }

        public async Task<ClassNameViewModel> CreateUpdate(ClassNameViewModel className)
        {
            var map = _mapper.Map<ClassName>(className);
            var result = _classesRepo.GetAll().FirstOrDefault(a => a.SubjectName == className.SubjectName);

            if (result != null)
            {
                result.Location = className.Location;
                result.TeacherName = className.TeacherName;
                result = await _classesRepo.Update(result);
            }
            else
                result = await _classesRepo.Add(map);

            var toReturn = _mapper.Map<ClassNameViewModel>(result);
            return toReturn;
        }

        public IEnumerable<ClassNameViewModel> GetAllIncludingStudents()
            => _mapper.Map<IEnumerable<ClassNameViewModel>>(_classesRepo.GetAllIncludingStudents());


        public IEnumerable<ClassNameViewModel> GetAll()
            => _mapper.Map<IEnumerable<ClassNameViewModel>>(_classesRepo.GetAll()) ?? new List<ClassNameViewModel>();
    }
}
