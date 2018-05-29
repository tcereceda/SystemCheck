using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization; // BsonClassMap
using MongoDB.Bson.Serialization.Conventions;

namespace M101DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("students");
            var col = db.GetCollection<BsonDocument>("grades");

      
            var filter = new BsonDocument("type", "homework");

            var list = await col.Find(filter)
                .Sort("{student}")
                .Sort("{score: 1}")
                .ForEachAsync()

            //foreach (var doc in list)
            //{
            //    Console.WriteLine(doc);
            //}

        }
        private class Person
        {
            public ObjectId Id { get; set; }

            public string Name { get; set; }

            public int Age { get; set; }

            public string Profesion { get; set; }

        }
    }
}
