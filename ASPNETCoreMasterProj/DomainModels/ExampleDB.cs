using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModels
{
    public class ExampleDB
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
    }
}
