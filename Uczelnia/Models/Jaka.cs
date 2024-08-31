using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Uczelnia.Models
{
    public class Jaka
    {
        [Key]
        public int JakaId { get; set; }

        public string jakatoocena { get; set; }


    }
}