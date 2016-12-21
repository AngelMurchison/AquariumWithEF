using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public override string ToString()
        {
            if (type.ToLower().First() == 'a')
            {
                return $"An {type} named {name}";
            }
            else
            {
                return $"A {type} named {name}";
            }
        }
    }
}
