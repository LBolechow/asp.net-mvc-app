using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uczelnia.Models
{
    public class Baza
    {
        public int BazaId { get; set; }
        public int StudentId { get; set; }
        public int PrzedmiotId { get; set; }
        public int ProwadzacyId { get; set; }

        public int OcenaId { get; set; }

        public int JakaId { get; set; }


        public Student Student { get; set; }
        public Przedmiot Przedmiot { get; set; }
        public Prowadzacy Prowadzacy { get; set; }

        public Ocena Ocena { get; set; }

        public Jaka Jaka { get; set; }


    }
}