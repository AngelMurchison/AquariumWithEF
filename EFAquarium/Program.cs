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
        public static void printCollection(IEnumerable<AquariumCreatures> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

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
            //db.SaveChanges();
            db = null;
        }

        public static void deleteAqCreature(int AqCreatureID)
        {
            var db = new AquariumContext();
            var toDelete = db.AquariumCreatures.First(f => f.Id == AqCreatureID);
            db.AquariumCreatures.Remove(toDelete);
            //db.SaveChanges();
            db = null;
        }

        public static void creaturesFromAquariumName(string aquariumname)
        {
            var db = new AquariumContext();
            var v = from AquariumCreatures in db.AquariumCreatures
                    join Aquariums in db.Aquariums
                    on AquariumCreatures.Aquarium.name equals Aquariums.name
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

        public static void distinctCitiesWithAquariums(string cityname)
        {
            var db = new AquariumContext();
            var v = from AquariumCreatures in db.AquariumCreatures
                       join aq in db.Aquariums on AquariumCreatures.AquariumID equals aq.Id
                       join c in db.Creatures on AquariumCreatures.CreatureID equals c.Id
                       join o in db.Oceans on AquariumCreatures.OceanID equals o.Id
                       where aq.city == $"{cityname}"
                       select new { aquarium = aq.city};
            var distinct = v.Distinct();
            Console.WriteLine(db.Aquariums.Single().city.ToString());

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            db = null;
        }

        public static void aquaticLifeInEachOcean()

        {
            var db = new AquariumContext();
            var test = from AquariumCreatures in db.AquariumCreatures
                       join aq in db.Aquariums on AquariumCreatures.AquariumID equals aq.Id
                       join c in db.Creatures on AquariumCreatures.CreatureID equals c.Id
                       join o in db.Oceans on AquariumCreatures.OceanID equals o.Id
                       select new { ocean = o.name, creature = c };
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            db = null;
        }

        static void Main(string[] args)
        {
            var db = new AquariumContext();

            //var creature = db.Creatures.First();
            //var creature2 = db.Creatures.First(f => f.Id.Equals(2)) as Creature;
            //var creature3 = db.Creatures.First(f => f.Id.Equals(3)) as Creature;
            //var creature4 = db.Creatures.First(f => f.Id.Equals(4)) as Creature;
            //var aquarium = db.Aquariums.First();
            //var ocean = db.Oceans.First();

            //var removethis = db.AquariumCreatures.First(c => c.CreatureID == null);
            //db.AquariumCreatures.Remove(removethis);
            //db.SaveChanges();

            // first creature, aq, ocean. create new aquatic creature, give it those items as properties

            // Create
            createAqCreature(1, 1, 1);

            // Read
            readAqCreature();

            // Update
            updateAqCreature(5, 1, 1, 2);
            updateAqCreature(6, 1, 1, 3);
            updateAqCreature(7, 1, 1, 4);
            //db.SaveChanges();

            // Delete
            deleteAqCreature(1);

            // An SQL Query that given an Aquarium Name, What AquaticLife is there
            Console.Write("new query \n");
            creaturesFromAquariumName("The Tampa Aquarium");

            // An SQL Query that, given an Ocean, What Aquariums have fish from that ocean
            Console.Write("new query \n");
            creaturesAndTheirAquariumsFromOcean("Arctic");

            // An SQL Query that Returns Only the Distinct (new topic) Cities that have aquariums
            Console.Write("new query \n");
            distinctCitiesWithAquariums("Tampa");

            // An SQL Query that Gives the Count(new topic) of How many species of AquaticLife live in each Ocean
            aquaticLifeInEachOcean();
        }
    }
}
