using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingLinq {
    public class Product {
        /*
        Properties
        */
        public string Title { get; set; }
        public double Price { get; set; }

        // Constructor method
        public Product (string title, double price) {
            this.Title = title;
            this.Price = price;
        }
    }
    class Program {
        static void Main (string[] args) {
            /*
            We can use curly braces to create instances of objects
            and immediately inject them into the List.
        */
            List<Product> shoppingCart = new List<Product> () {
                new Product ("Bike", 109.99),
                new Product ("Mittens", 6.49),
                new Product ("Lollipop", 0.50),
                new Product ("Pocket Watch", 584.00)
            };

            /*
                IEnumerable is an interface, which we'll get to later,
                that we're using here to create a collection of Products
                that we can iterate over.
            */
            IEnumerable<Product> inexpensive = from product in shoppingCart
            where product.Price < 100.00
            orderby product.Price descending
            select product;
            Console.WriteLine("-------- in-Expensive -------------");
            foreach (Product p in inexpensive) {
                Console.WriteLine ($"{p.Title} ${p.Price:f2}");
            }

            /*
                You can also use `var` when creating LINQ collections. The
                following variable will still be typed as List<Product> by
                the compiler, but you don't need to type that all out.
            */
            var expensive = from product in shoppingCart
            where product.Price >= 100.00
            orderby product.Price descending
            select product;
            Console.WriteLine("---------------- Expensive ---------------");
            foreach (Product p in expensive) {
                Console.WriteLine ($"{p.Title} ${p.Price:f2}");
            }

        }
    }
}
