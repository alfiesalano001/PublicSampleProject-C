using DomainModels.Enum;

namespace DomainModels.Entity
{
    public class ClassName: EntityBase
    {
        public string Location { get; set; }
        public string TeacherName { get; set; }
        public SubjectName SubjectName { get; set; }
    }
}
