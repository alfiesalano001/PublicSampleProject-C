using DomainModels.BindingModels;
using DomainModels.Enum;
using System.Collections.Generic;

namespace DomainModels.Entity
{
    public class ClassName: EntityBase
    {
        public string Location { get; set; }
        public string TeacherName { get; set; }
        public SubjectName SubjectName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

