using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.BindingModels
{
    public class StudentViewModel
    {
        public int Id { get; private set; }
        public int ClassNameId { get; set; }
        public string StudentName { get => $"{FirstName} {LastName}"; }

        [Required(ErrorMessage = "This FirstName name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This LastName name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This Age name is required.")]
        public int Age { get; set; }
        public decimal GPA { get; set; }
    }
}
