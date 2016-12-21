using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFAquarium.Models
{
    class AquariumCreatures
    {
        public int Id { get; set; }
        public int? CreatureID { get; set; }
        public virtual Creature Creature { get; set; }
        public int? AquariumID { get; set; }
        public virtual Aquarium Aquarium { get; set; }
        public int? OceanID { get; set; }
        public virtual Ocean Ocean { get; set; }

        public override string ToString()
        {
            var rv = $"{Id}. {Creature.type}, {Creature.length}, {Creature.weight}, {Creature.color}, {Creature.name}, {this.Ocean.name}, {this.Aquarium.name}";
            return rv;
        }
    }
}

