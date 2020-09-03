using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace TestMisc
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDebug();
            Console.ReadLine();
        }
        public static void TestDebug()
        {
            int selectowner = 1;
            int selectgallery;
            int selectitem;

            List<Owner> owners = new List<Owner>();
            owners.Add(new Owner { OwnerId = 0, Name = "Owner 0" });
            owners.Add(new Owner { OwnerId = 1, Name = "Owner 1" });
            owners.Add(new Owner { OwnerId = 2, Name = "Owner 2" });

            List<Gallery> galleries = new List<Gallery>();

            galleries.Add(new Gallery { GalleryId = 0, OwnerId = 1, Name = "Gallery 0" });
            galleries.Add(new Gallery { GalleryId = 1, OwnerId = 1, Name = "Gallery 1" });
            galleries.Add(new Gallery { GalleryId = 2, OwnerId = 2, Name = "Gallery 2" });
            galleries.Add(new Gallery { GalleryId = 3, OwnerId = 2, Name = "Gallery 3" });
            galleries.Add(new Gallery { GalleryId = 4, OwnerId = 1, Name = "Gallery 4" });

            List<Item> items = new List<Item>();

            items.Add(new Item { ItemId = 0, OwnerId = 1, Name = "Item 0" });
            items.Add(new Item { ItemId = 1, OwnerId = 1, Name = "Item 1" });
            items.Add(new Item { ItemId = 2, OwnerId = 1, Name = "Item 2" });
            items.Add(new Item { ItemId = 3, OwnerId = 2, Name = "Item 3" });
            items.Add(new Item { ItemId = 4, OwnerId = 2, Name = "Item 4" });
            items.Add(new Item { ItemId = 5, OwnerId = 3, Name = "Item 5" });
            items.Add(new Item { ItemId = 6, OwnerId = 1, Name = "Item 6" });
            items.Add(new Item { ItemId = 7, OwnerId = 1, Name = "Item 7" });
            items.Add(new Item { ItemId = 8, OwnerId = 2, Name = "Item 8" });
            items.Add(new Item { ItemId = 9, OwnerId = 3, Name = "Item 9" });


            //var selected = (from gallery in galleries
            //               where gallery.OwnerId == 1
            //               select gallery).ToList<Gallery>();

            //var selected = (from gallery in galleries
            //                where gallery.OwnerId == 1
            //                select new { GalleryID = gallery.GalleryId, Name = gallery.Name }).ToList();

            //var selected = from gallery in galleries
            //               join item in items on gallery.OwnerId equals item.OwnerId
            //               select new { GalleryId = gallery.GalleryId, OwnerId = gallery.OwnerId, ItemId = item.ItemId, Name = item.Name };

            var selected = from owner in owners
                           join gallery in galleries on owner.OwnerId equals gallery.OwnerId
                           join item in items on gallery.OwnerId equals item.OwnerId
                           where owner.OwnerId == selectowner & gallery.GalleryId == 0
                           select new { OwnerId = owner.OwnerId, OwnerName = owner.Name ,GalleryId = gallery.GalleryId, GalleryName = gallery.Name, ItemId = item.ItemId, ItemName = item.Name };

            foreach (var select in selected)
            {
                Console.WriteLine($"OwnerId: {select.OwnerId}, Gallery ID: {select.GalleryId}, ItemId: {select.ItemId}");
            }

            //Console.WriteLine("This is a test of TestDebug");
        }
        public class Owner
        {
            public int OwnerId { get; set; }
            public string Name { get; set; }
        }

        public class Gallery
        {
            public int GalleryId { get; set; }
            public int OwnerId { get; set; }
            public string Name { get; set; }
        }

        public class Item
        {
            public int ItemId { get; set; }
            public int OwnerId { get; set; }
            public string Name { get; set; }
        }
    }
}
