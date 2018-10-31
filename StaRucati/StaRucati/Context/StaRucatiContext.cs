using StaRucati.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StaRucati.Context
{
    public class StaRucatiContext : DbContext
    {
        public DbSet<Restoran> Restorani { get; set; }
        public DbSet<Jelo> Jela { get; set; }
    }
}