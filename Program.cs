using System;
using System.Linq;
using Store;
using Algorithms;

namespace ProductSortingAndFiltering
{
    class Program
    {
        static void Main()
        {
            //task 8.1
            Storage storage = new();
            storage.GetProductsFromFile(@"C:\Users\ihorm\source\repos\Store\products.txt");
            var anotherStorage = new Storage()
            {
                new Product("Garlic", 0.5, 5, 10),
                Product.Parse("Name: Bread, Price: $1.50, Weight: 0.3, Consume in 3 days"),
                Product.Parse("Name: Soda, Price: $1.00, Weight: 0.5, Consume in 1 days"),
                new Product("Chocolate", 2, .1, 30)
            };

            var arr = storage.Products.ToArray();

            //non-generic method
            arr.BubbleSort((object pr1, object pr2) => (pr1 as Product).Price < (pr2 as Product).Price ? -1 : 1);
            Console.WriteLine(new Storage(arr));

            //generic method
            arr.BubbleSort((pr1, pr2) => pr1.Weight < pr2.Weight ? -1 : 1);
            Console.WriteLine(new Storage(arr));

            //task 8.2
            Console.WriteLine("A:");
            Console.WriteLine(storage);
            Console.WriteLine("B:");
            Console.WriteLine(anotherStorage);

            var intersect = storage.Products.Intersect(anotherStorage.Products);
            Console.WriteLine("Intersection:");
            Console.WriteLine(new Storage(intersect));
            Console.WriteLine("A - B:");
            Console.WriteLine(new Storage(storage.Products.Except(anotherStorage.Products)));
            Console.WriteLine("A+B - intersection:");
            Console.WriteLine(new Storage(storage.Products.Concat(anotherStorage.Products).Except(intersect)));

            Console.Read();
        }
    }
}
