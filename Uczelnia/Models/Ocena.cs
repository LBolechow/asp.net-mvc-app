using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Uczelnia.Models
{
    public class Ocena
    {
        [Key]
        public int OcenaId { get; set; }

        public int ocenka { get; set; }

      
  
    }
}