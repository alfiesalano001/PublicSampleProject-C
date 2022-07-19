using DomainModels.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repositories.Interface;
using Services.Interface;
using System;

namespace CoreProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassesController : Controller
    {
        readonly ILogger<ClassesController> _logger;
        readonly IClassesService _classesService;
        public ClassesController(ILogger<ClassesController> logger, IClassesService classesService)
        {
            _logger = logger;
            _classesService = classesService;
        }

        [HttpGet("GetAllSubjects")]
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogInformation($"ClassesController - GetAllSubjects.");
                var response = _classesService.GetAll();

                if (response == null)
                    return new NotFoundResult();

                return Ok(response);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Exception error for ClassesController/GetAll Error: {ex}");
                return BadRequest($"GetAllSubjects - {ex}");
            }
        }

        [HttpGet("GetAllIncludingStudents")]
        public IActionResult GetAllIncludingStudents()
        {
            try
            {
                _logger.LogInformation($"ClassesController - GetAllIncludingStudents.");
                var response = _classesService.GetAllIncludingStudents();

                if (response == null)
                    return new NotFoundResult();

                return Ok(response);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Exception error for ClassesController/GetAllSubjects Error: {ex}");
                return BadRequest($"GetAllSubjects - {ex}");
            }
        }

        [HttpPut("CreateUpdateClassName")]
        public IActionResult CreateUpdateClassName(ClassNameViewModel classname)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _logger.LogInformation($"StudentController - CreateUpdateStudent {classname}.");
                var response = _classesService.CreateUpdate(classname);
                return Ok(response.Result);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Exception error for MenuController/GetAll Error: {ex}");
                return BadRequest($"GetAllStudents - {ex}");
            }
        }
    }
}
