using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAquarium.Models
{
    class Creature
    {
        public int Id { get; set; }
        public string type { get; set; }
        public double? length { get; set; }
        public double? weight { get; set; }
        public string color { get; set; }
        public string name { get; set; }
        public int? oceanId { get; set; }
        public virtual Ocean ocean { get; set; }
        public int? aquariumId { get; set; }
        public virtual Aquarium aquarium { get; set; }
    }
}
