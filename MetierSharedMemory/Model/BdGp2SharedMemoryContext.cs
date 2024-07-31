using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace MetierSharedMemory.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdGp2SharedMemoryContext:DbContext
    {
        public BdGp2SharedMemoryContext():base("connGp2SharedMemory") { }

        public DbSet<Personne> personnes { get; set; }

        public DbSet<Encadreur> encadreurs { get; set; }

        public DbSet<Memoire> memoires { get; set; }
        public DbSet<Td_Erreur> td_Erreurs { get; set; }
    }
}