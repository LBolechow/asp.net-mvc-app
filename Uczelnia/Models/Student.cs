using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Uczelnia.Models
{
    public class Student
    {
 
        [Key]
        public int StudentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string index { get; set; }

    }

}
