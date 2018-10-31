using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaRucati.Models
{
    public class Jelo
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public int RestoranId { get; set; }

        public virtual Restoran Restoran { get; set; }

    }
}