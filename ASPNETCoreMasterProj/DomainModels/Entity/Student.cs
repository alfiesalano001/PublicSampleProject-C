namespace DomainModels.Entity
{
    public class Student : EntityBase
    {
        public int ClassNameId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal GPA { get; set; }
    }
}
