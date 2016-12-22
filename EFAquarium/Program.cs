using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFAquarium.Models;


namespace EFAquarium
{
    class Program
    { 
        public static void readAqCreature()
        {
            var db = new AquariumContext();
            var test = /*db.AquariumCreatures
                        from what ur joining vvv         vvv  from what ur pointing to 
                       .Join(db.Oceans, fk => fk.OceanID, pk => pk.Id, (aqc, o) =>
                       new { AquariumCreatures = aqc, Ocean = o }) // <<<< the object ur making.
                       .Join(db.Creatures, fk => fk.AquariumCreatures.CreatureID, pk => pk.Id, (a, c) =>
                       new { AquariumCreatures = a.AquariumCreatures, Ocean = a.Ocean, Creature = c })
                       .Join(db.Aquariums, fk => fk.AquariumCreatures.AquariumID, pk => pk.Id, (a, aq) =>
                       new {AquariumCreatures = a.AquariumCreatures, Ocean = a.Ocean, Creature = a.Creature, Aquarium = aq });*/
                       from AquariumCreatures in db.AquariumCreatures
                       join aq in db.Aquariums on AquariumCreatures.AquariumID equals aq.Id
                       join c in db.Creatures on AquariumCreatures.CreatureID equals c.Id
                       join o in db.Oceans on AquariumCreatures.OceanID equals o.Id
                       select new { id = AquariumCreatures.Id, aquarium = aq.name, creature = c, ocean = o.name };
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            db = null;
        }
        public static void updateAqCreature(int AqCreatureID = 1, int aquariumID = 1, int creatureID = 1, int oceanID = 1) // how to make default values unchanged, idt actually updates
        {
            var db = new AquariumContext();
            var toUpdate = db.AquariumCreatures.First(f => f.Id == AqCreatureID);
            toUpdate.AquariumID = aquariumID;
            toUpdate.CreatureID = creatureID;
            toUpdate.OceanID = oceanID;            
            db.SaveChanges();
            db = null;
        }
        public static void createAqCreature(int creatureID = 1, int aquariumID = 1, int oceanID = 1)
        {
            var db = new AquariumContext();
            var aqCreature = new AquariumCreatures() { CreatureID = creatureID, AquariumID = aquariumID, OceanID = oceanID };
            db.AquariumCreatures.Add(aqCreature);
            db.SaveChanges();
            db = null;
        }
        public static void deleteAqCreature(int AqCreatureID)
        {
            var db = new AquariumContext();
            var toDelete = db.AquariumCreatures.First(f => f.Id == AqCreatureID);
            db.AquariumCreatures.Remove(toDelete);
            db.SaveChanges();
            db = null;
        }

        public static void creaturesFromAquariumName(string aquariumname)
        {
            var db = new AquariumContext();
            var v = from AquariumCreatures in db.AquariumCreatures
                    join Aquariums in db.Aquariums
                    on AquariumCreatures.Aquarium.name equals Aquariums.name
                    where Aquariums.name == aquariumname
                    select new { AquariumCreatures.Creature, Aquariums.name };
            foreach (var item in v)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            db = null;
        }
        public static void creaturesAndTheirAquariumsFromOcean(string oceanname)
        {
            var db = new AquariumContext();
            var v = from AquariumCreatures in db.AquariumCreatures
                       join aq in db.Aquariums on AquariumCreatures.AquariumID equals aq.Id
                       join c in db.Creatures on AquariumCreatures.CreatureID equals c.Id
                       join o in db.Oceans on AquariumCreatures.OceanID equals o.Id
                       where o.name == oceanname
                       select new { creature = c, aquarium = aq.name, ocean = o.name };

            foreach (var item in v)
            {
                item.ToString();
                Console.WriteLine(item);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            db = null;
        }
        public static void distinctCitiesWithAquariums()
        {
            var db = new AquariumContext();
            var v = from AquariumCreatures in db.AquariumCreatures
                       join aq in db.Aquariums on AquariumCreatures.AquariumID equals aq.Id
                       join c in db.Creatures on AquariumCreatures.CreatureID equals c.Id
                       join o in db.Oceans on AquariumCreatures.OceanID equals o.Id
                       select new { aquarium = aq.city };
            var distinct = v.Distinct();
            foreach (var item in distinct)
            {
                item.ToString();
                Console.WriteLine(item);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            db = null;
        }
        public static void creaturesInEachOcean()

        {
            var db = new AquariumContext();
            var test = from AquariumCreatures in db.AquariumCreatures
                       join aq in db.Aquariums on AquariumCreatures.AquariumID equals aq.Id
                       join c in db.Creatures on AquariumCreatures.CreatureID equals c.Id
                       join o in db.Oceans.Distinct() on AquariumCreatures.OceanID equals o.Id
                       select new { ocean = o.name, creature = c };
            var arcticcounter = 0;
            var pacificcounter = 0;
            var atlanticcounter = 0;
            var southcounter = 0;
            var indiancounter = 0;
            foreach (var item in test)
            {
                Console.WriteLine(item);
                var arcticbool = item.ocean.Equals("Arctic");
                if (arcticbool) { arcticcounter++; }
                var pacificbool = item.ocean.Equals("Pacific");
                if (pacificbool) { pacificcounter++; }
                var atlanticbool = item.ocean.Equals("Atlantic");
                if (atlanticbool) { atlanticcounter++; }
                var southbool = item.ocean.Equals("South");
                if (southbool) { southcounter++; }
                var indianbool = item.ocean.Equals("Indian");
                if (indianbool) { indiancounter++; }
            };
            Console.WriteLine($"Arctic: {arcticcounter}");
            Console.WriteLine($"Pacific: {pacificcounter}");
            Console.WriteLine($"Atlantic: {atlanticcounter}");
            Console.WriteLine($"South: {southcounter}");
            Console.WriteLine($"Indian: {indiancounter}");

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            db = null;
        }

        static void Main(string[] args)
        {
            /* ! CREATE, UPDATE, DELETE SAVE TO DATABASE ! */

            /* Create */
            //createAqCreature(3, 1, 3);

            /* Update */
            //updateAqCreature(9, 2, 3, 1);

            /* Delete */
            //deleteAqCreature(8);

            /* Read */
            Console.WriteLine("All creatures in all aquariums.");
            Console.WriteLine("LOADING");
            readAqCreature();

            // A SQL Query that given an aquarium Name, what creatures live there
            Console.WriteLine("All Aquatic Life at the Tampa Aquarium");
            creaturesFromAquariumName("The Tampa Aquarium");

            // A SQL Query that, given an ocean, what aquariums have creatures from that ocean
            Console.WriteLine("All aquatic life in the Arctic");
            creaturesAndTheirAquariumsFromOcean("Arctic");

            // A SQL Query that returns only the distinct cities that have aquariums
            Console.WriteLine("Cities that have aquariums");
            distinctCitiesWithAquariums();

            // A SQL Query that gives the count of How many creatures are from each Ocean
            creaturesInEachOcean();
        }
    }
}
