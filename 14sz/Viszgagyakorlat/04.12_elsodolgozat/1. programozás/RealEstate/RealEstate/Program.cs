using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RealEstate
{
    internal class Program
    {

        class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Ad
        {
            public int Area { get; set; }
            public Category Category { get; set; }
            public DateTime CreateAt { get; set; }
            public string Description { get; set; }
            public int Floor { get; set; }
            public bool FreeOfCharge { get; set; }
            public int Id { get; set; }
            public string ImageUrl { get; set; }
            public string LatLong { get; set; }
            public int Rooms { get; set; }
            public Seller Seller { get; set; }

            public static List<Ad> LoadFromCSV(string FileName)
            {
                using (var reader = new StreamReader(FileName))
                {
                    List<Ad> list = new List<Ad>();
                    reader.ReadLine(); // elso sor kihagyasa
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        Ad ad = new Ad();


                        ad.Id = int.Parse(values[0]);
                        ad.Rooms = int.Parse(values[1]);
                        ad.LatLong = values[2];
                        ad.Floor = int.Parse(values[3]);
                        ad.Area = int.Parse(values[4]);
                        ad.Description = values[5];
                        ad.FreeOfCharge = values[6].Equals("1") ? true : false;
                        ad.ImageUrl = values[7];
                        ad.CreateAt = DateTime.Parse(values[8]);

                        ad.Seller = new Seller();
                        ad.Seller.Id = int.Parse(values[9]);
                        ad.Seller.Name = values[10];
                        ad.Seller.Phone = values[11];

                        ad.Category = new Category();
                        ad.Category.Id = int.Parse(values[12]);
                        ad.Category.Name = values[13];

                        list.Add(ad);
                    }

                    return list;
                }
            }
        }

        class Seller
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
        }
        static void Main(string[] args)
        {

            List<Ad> ads = Ad.LoadFromCSV("realestates.csv");

            ads.Sort((ad1, ad2) => ad1.Id.CompareTo(ad2.Id));

            #region List
            //foreach (var ad in ads)
            //{
            //    Console.WriteLine($"Id: {ad.Id}");
            //    //Console.WriteLine($"Rooms: {ad.Rooms}");
            //    //Console.WriteLine($"LatLong: {ad.LatLong}");
            //    //Console.WriteLine($"Floor: {ad.Floor}");
            //    //Console.WriteLine($"Area: {ad.Area}");
            //    //Console.WriteLine($"Description: {ad.Description}");
            //    //Console.WriteLine($"FreeOfCharge: {ad.FreeOfCharge}");
            //    //Console.WriteLine($"ImageUrl: {ad.ImageUrl}");
            //    //Console.WriteLine($"CreateAt: {ad.CreateAt}");
            //    //Console.WriteLine($"Seller Id: {ad.Seller.Id}");
            //    //Console.WriteLine($"Seller Name: {ad.Seller.Name}");
            //    //Console.WriteLine($"Seller Phone: {ad.Seller.Phone}");
            //    //Console.WriteLine($"Category Id: {ad.Category.Id}");
            //    //Console.WriteLine($"Category Name: {ad.Category.Name}");
            //    Console.WriteLine();
            //}
            #endregion 


            feladat6(ads);
            feladat8(ads);

            Console.ReadKey();
        }

        private static double DistanceTo(double lat1, double lon1, double lat2, double lon2)
        {
            double distance = Math.Sqrt(Math.Pow(lat2 - lat1, 2) + Math.Pow(lon2 - lon1, 2));
            return distance;
        }


        private static void feladat8(List<Ad> list)
        {
            var mesevarLatitude = 47.4164220114023;
            var mesevarLongitude = 19.066342425796986;

            try
            {
                var closestAd = list
                    .OrderBy(ad => DistanceTo(
                        double.Parse(ad.LatLong.Split(',')[0]), //lat1
                        double.Parse(ad.LatLong.Split(',')[1]), //lon1
                        mesevarLatitude,                        //lat2
                        mesevarLongitude))                      //lon2
                    .FirstOrDefault();

                Console.WriteLine("2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai:");
                Console.WriteLine($"\tEladó neve: {closestAd.Seller.Name}");
                Console.WriteLine($"\tEladó telefonja: {closestAd.Seller.Phone}");
                Console.WriteLine($"\tAlapterület: {closestAd.Area}");
                Console.WriteLine($"\tSzobák száma: {closestAd.Rooms}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void feladat6(List<Ad> list)
        {
            var groundFloorAds = list.Where(ad => ad.Floor == 0);
            double averageArea = groundFloorAds.Average(ad => ad.Area);
            Console.WriteLine("1. Földszinti ingatlanok átlagos alapterülete: " + String.Format("{0:0.00}", averageArea) + "m2");
        }
    }
}
