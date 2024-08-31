using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Uczelnia.Models
{
    public class Prowadzacy
    {
    
        [Key]
        public int ProwadzacyId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public string Identyfikator { get; set; }
      
    }
}