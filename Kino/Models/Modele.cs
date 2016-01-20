using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
namespace Kino.Models
{
    public class Bilet
    {
        public Bilet()
        {
            this.Klienci = new List<Klient>();

        }
        [Key]
        public int bilet_id { get; set; }
        public string rodzaj { get; set; }
        public string opis { get; set; }
        public int cena { get; set; }


        public virtual ICollection<Klient> Klienci { get; set; }
    }

    public class Klient
    {
        public Klient() { }
        [Key]
        public int klient_id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public DateTime data_zak { get; set; }

        public int bilet_id { get; set; }

        [ForeignKey("bilet_id")]
        public virtual Bilet Bilet { get; set; }

    }
    public class MyDBContext : DbContext
    {
        public DbSet<Bilet> Bilety { get; set; }
        public DbSet<Klient> Klienci { get; set; }

    }
}