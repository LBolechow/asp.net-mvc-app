using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Uczelnia.Models
{
    public class Przedmiot
    {
     
        [Key]
        public int PrzedmiotId { get; set; }
        public string NazwaPrzemiotu { get; set; }

    
      



    }
}