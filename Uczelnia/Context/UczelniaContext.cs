using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uczelnia.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Uczelnia.Context
{
    public class UczelniaContext : DbContext
    {

        public UczelniaContext() : base("UczelniaContext")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Prowadzacy> Prowadzacy { get; set; }
        public DbSet<Przedmiot> Przedmioty { get; set; }

        public DbSet<Ocena> Ocena { get; set; }

        public DbSet<Jaka> Jaka { get; set; }

        public DbSet<Baza> Baza { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}