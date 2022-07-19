using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Entity
{
    public class Student : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal GPA { get; set; }
        public int ClassNameId { get; set; }
    }
}
