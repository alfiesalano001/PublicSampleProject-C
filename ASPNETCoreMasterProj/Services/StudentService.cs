using AutoMapper;
using DomainModels.BindingModels;
using DomainModels.Entity;
using Microsoft.Extensions.Logging;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StudentService : ServiceBase<StudentService>, IStudentService
    {
        readonly IStudentRepositories _studentRepo;

        public StudentService(IMapper mapper, ILogger<StudentService> logger, IStudentRepositories studentRepo)
            : base(mapper, logger)
        {
            _studentRepo = studentRepo;
        }

        public async Task<StudentViewModel> CreateUpdate(StudentViewModel student)
        {
            var result = _studentRepo.GetAll().FirstOrDefault(a => a.LastName == student.LastName && a.ClassNameId == student.ClassNameId);

            if (result != null)
            {
                result.Age = student.Age;
                result.GPA = student.GPA;                
                result = await _studentRepo.Update(result);
            }
            else
            {
                var map = _mapper.Map<Student>(student);
                result = await _studentRepo.Add(map);
            } 

            var toReturn = _mapper.Map<StudentViewModel>(result);
            return toReturn;
        }

        public async Task Delete(int id)
            => await _studentRepo.Delete(id);
    }
}
