using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaRucati.Models
{
    public class Restoran
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }

        public virtual List<Jelo> Jela { get; set; }
    }
}