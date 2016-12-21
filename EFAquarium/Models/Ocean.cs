using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFAquarium.Models
{
    class Ocean
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string averageTemperature { get; set; }
    }
}
