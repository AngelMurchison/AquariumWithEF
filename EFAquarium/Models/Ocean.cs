using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAquarium.Models
{
    class Ocean
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string averageTemperature { get; set; }
        public ICollection<Creature> CreaturesFrom { get; set; } = new HashSet<Creature>();
    }
}
