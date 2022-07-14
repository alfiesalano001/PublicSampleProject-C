using DomainModels.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.BindingModels
{
    public class ClassNameViewModel
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "This Location name is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "This TeacherName name is required.")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "This SubjectName name is required.")]
        public SubjectName SubjectName { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}
