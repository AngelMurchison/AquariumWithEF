﻿using System;
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
            // var aqcreatures = db.AquariumCreatures.ToList();
            //foreach (var item in db.AquariumCreatures)
            //{
            // var joineditem = db.AquariumCreatures.First(f => f.Id == item.Id);
            // Console.WriteLine(item);
            // }
            var test = db.AquariumCreatures.Join
                       (db.Oceans, fk => fk.OceanID, pk => pk.Id, (aqc, o) =>
                       new { AquariumCreatures = aqc, Ocean = o })
                       .Join(db.Creatures, fk => fk.AquariumCreatures.CreatureID, pk => pk.Id, (a, c) =>
                       new { AquariumCreatures = a.AquariumCreatures, Ocean = a.Ocean, Creature = c })
                       .Join(db.Aquariums, fk => fk.AquariumCreatures.AquariumID, pk => pk.Id, (a, aq) =>
                       new {AquariumCreatures = a.AquariumCreatures, /*Ocean = a.Ocean, Creature = a.Creature,*/ Aquarium = aq });
                                            

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
            //db.SaveChanges();
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

        public static IQueryable creaturesFromAquariumName(string aquariumname)
        { 
            var db = new AquariumContext();
            var v = from AquariumCreatures in db.AquariumCreatures
                     join Aquariums in db.Aquariums
                     on AquariumCreatures.Aquarium.name equals Aquariums.name
                     select new { AquariumCreatures.Creature, Aquariums.name };
            //var rv = v.ToList();
            return v;
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
            updateAqCreature(1, 1, 1, 1);

            // Delete
            deleteAqCreature(1);

            // An SQL Query that given an Aquarium Name, What AquaticLife is there
            var sql1 = creaturesFromAquariumName("The Tampa Aquarium").ToListAsync();
            Console.WriteLine(sql1);
            Console.ReadLine();


            //var creaturesfromaquarium = creaturesFromAqName.ToList();
            //foreach (var creature in creaturesfromaquarium)
            //{
            //    Console.WriteLine(creature);
            //}

            //Console.ReadLine();

            //var v = from AquariumCreatures in db.AquariumCreatures
            //        join Aquariums in db.Aquariums
            //        on AquariumCreatures.Aquarium.name equals Aquariums.name
            //        select new { AquariumCreatures.Creature, Aquariums.name };

            // An SQL Query that, given an Ocean, What Aquariums have fish from that ocean
            //var fishFromOcean = from AquariumCreatures in db.AquariumCreatures
            //                    join Ocean in db.Oceans
            //                    on AquariumCreatures.Ocean.name equals Ocean.name

            //                    into 

            // An SQL Query that Returns Only the Distinct (new topic) Cities that have aquariums
            // An SQL Query that Gives the Count(new topic) of How many species of AquaticLife live in each Ocean
        }
    }
}
