using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFAquarium.Models;

namespace EFAquarium.Models
{
    class AquariumContext: DbContext
    {
        public AquariumContext() : base()
        {

        }

        public DbSet<Creature> Creatures { get; set; }
        public DbSet<Aquarium> Aquariums { get; set; }
        public DbSet<Ocean> Oceans { get; set; }
        public DbSet<AquariumCreatures> AquariumCreatures { get; set; }
    }
}
