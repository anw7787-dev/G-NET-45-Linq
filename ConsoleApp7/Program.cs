using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    class Product
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    class Order
    {
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // simple data
            var products = new List<Product>()
            {
                new Product { ProductName="Chai", Category="Beverages", UnitPrice=18, UnitsInStock=39 },
                new Product { ProductName="Chang", Category="Beverages", UnitPrice=19, UnitsInStock=17 },
                new Product { ProductName="Aniseed Syrup", Category="Condiments", UnitPrice=10, UnitsInStock=13 },
                new Product { ProductName="Chef Anton", Category="Condiments", UnitPrice=22, UnitsInStock=0 },
                new Product { ProductName="Ikura", Category="Seafood", UnitPrice=31, UnitsInStock=20 },
                new Product { ProductName="Konbu", Category="Seafood", UnitPrice=6, UnitsInStock=24 }
            };

            var orders = new List<Order>()
            {
                new Order { CustomerID="A1", OrderDate=new DateTime(1996,1,1)},
                new Order { CustomerID="A2", OrderDate=new DateTime(1997,5,1)},
                new Order { CustomerID="A3", OrderDate=new DateTime(1998,3,1)}
            };

            // 1
            Console.WriteLine("Q1:");
            var seafood = products.Where(p => p.Category == "Seafood");
            foreach (var p in seafood)
                Console.WriteLine(p.ProductName + " - " + p.UnitPrice);

            // 2
            Console.WriteLine("\nQ2:");
            var names = products.Select(p => p.ProductName);
            foreach (var n in names)
                Console.WriteLine(n);

            // 3
            Console.WriteLine("\nQ3:");
            var sorted = products.OrderBy(p => p.UnitPrice);
            foreach (var p in sorted)
                Console.WriteLine(p.ProductName + " - " + p.UnitPrice);

            // 4
            Console.WriteLine("\nQ4:");
            var range = products.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
            foreach (var p in range)
                Console.WriteLine(p.ProductName);

            // 5
            Console.WriteLine("\nQ5:");
            var condiments = products.Where(p => p.Category == "Condiments" && p.UnitsInStock > 0);
            foreach (var p in condiments)
                Console.WriteLine(p.ProductName);

            // 6
            Console.WriteLine("\nQ6:");
            var result = products.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                Status = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });

            foreach (var r in result)
                Console.WriteLine(r.Name + " - " + r.Price + " - " + r.Status);

            // 7
            Console.WriteLine("\nQ7:");
            int count = 1;
            foreach (var p in products)
            {
                Console.WriteLine(count + ". " + p.ProductName);
                count++;
            }

            // 8
            Console.WriteLine("\nQ8:");
            var sorted2 = products
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var p in sorted2)
                Console.WriteLine(p.Category + " - " + p.ProductName);

            // 9
            Console.WriteLine("\nQ9:");
            var bev = products
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);

            foreach (var p in bev)
                Console.WriteLine(p.ProductName + " - " + p.UnitsInStock);

            // 10 (query syntax)
            Console.WriteLine("\nQ10:");
            var q10 = from o in orders
                      where o.OrderDate.Year >= 1997
                      select o;

            foreach (var o in q10)
                Console.WriteLine(o.CustomerID + " - " + o.OrderDate.Year);

            // 11
            Console.WriteLine("\nQ11:");
            int i = 1;
            foreach (var p in products)
            {
                Console.WriteLine(i + " - " + p.ProductName);
                i++;
            }

            // 12
            Console.WriteLine("\nQ12:");
            string[] arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRrY" };

            var sortedWords = arr
                .OrderBy(x => x.Length)
                .ThenBy(x => x.ToLower());

            foreach (var w in sortedWords)
                Console.WriteLine(w);

            // 13
            Console.WriteLine("\nQ13:");
            string[] arr2 = { "apple", "bird", "ship", "milk", "king", "iron" };

            var res = arr2
                .Where(x => x.Length > 1 && x[1] == 'i')
                .Reverse();

            foreach (var w in res)
                Console.WriteLine(w);

            Console.WriteLine("\nDone");
        }
    }
}