/*
 * CS3260 lab 10
"I declare that the following source code was written solely by me. I understand that copying any source code, in whole or in part, constitutes cheating, 
and that I will receive a zero on this project if I am found in violation of this policy.”
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_Lab12_KH
{
    class Program
    {
        static void Main(string[] args)
        {
            // The following code was provided by the instructor.
            int[] odds = { 1, 3, 5, 7, 9, 11, 13, 1, 17, 19 };
            int[] evens = { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18 };
            var data = new[]
            {
                new { ID = 100, Name = "Grumpy", Job = "Miner" },
                new { ID = 100, Name = "John", Job = "Auto Salesman" },
                new { ID = 200, Name = "Amber", Job = "Scientist" },
                new { ID = 300, Name = "Luke", Job = "M.D." },
                new { ID = 400, Name = "Isabella", Job = "Professor" },
                new { ID = 500, Name = "Liam", Job = "Student" },
                new { ID = 600, Name = "Ava", Job = "Programmer" },
                new { ID = 220, Name = "Royal", Job = "Pharmacist" },
                new { ID = 150, Name = "Meghan", Job = "Princess" },
                new { ID = 175, Name = "Lucas", Job = "Nurse" }
            };
            // END of code provided by the instructor.
            //Query 0 – Find the values in odds that are divisible(no remainder) by three(3) and write these values to the Console.
            Console.Write("QUERY 0: \n");
            var divisibleByThreeIds =
            from number in odds
            where (number % 3) == 0
            select number;
            foreach (int number in divisibleByThreeIds)
            {
                Console.Write(" The number {0} is divisible by three. ", number);
                Console.Write("\n");
            }
            //Query 1 – Find the values in evens and the values in odds where the evens values are greater than two(2) times the value of odds values. Write these values to the Console.
            Console.Write("QUERY 1: \n");
            var doubleValueIds =
            from number in evens
            from num in odds
            where (number == num * 2)
            select number;
            foreach (int number in doubleValueIds)
            {
                Console.Write(" The number {0} is equal to double of an odd number. ", number);
                Console.Write("\n");
            }
            //Query 2 – Find values in data where the ID is greater than 100 and less than 500 and the Name contains a ‘y’ or Job ends with ‘e’ or Job contains ‘e’ or Job equals “Student” or Job equals “Programmer”. Write these values to the Console.
            // The final 3 clauses are completely redundant/unnecessary because the query is already grabbing every item where Job.Contains("e") but I didn't want to act clever and change the query.
            Console.Write("QUERY 2: \n");
            string V = "e";
            var teenAgerStudent = from s in data 
                                  where s.ID > 100 && s.ID < 500 && s.Name.Contains('y') || s.Job.EndsWith(V) || s.Job.Contains("e") ||s.Job == "Student" || s.Job == "Programmer"
                                  select s;

            foreach (var s in teenAgerStudent)
            {
                Console.Write(" {0} matched expected criteria. ", s);
                Console.Write("\n");
            }
            //Query 3 – Find values in productList where the ProductID is greater than 10 and less than 66,
            //order in descending order by UnitsInStock and write the ProductName and UnitsInStock to the Console.
            Console.Write("QUERY 3: \n");
            var prodList = GetProductList();
            var products =
                from prod in prodList
                where (prod.ProductID > 10 && prod.ProductID < 66)
                orderby prod.UnitsInStock descending
                select prod;
                            foreach (var prod in products)
                            {
                                Console.Write("\n");
                                Console.Write("Product name: {0}", prod.ProductName);
                                Console.Write("\n");
                                Console.Write("Units: {0}", prod.UnitsInStock);
                                Console.Write("\n");
                            }
            //Query 4 – Write a complex query on the productList that shows you know how to use at least ten(10)
            //different LINQ operations i.e.let, where, orderby, into, from, etc.
            Console.Write("\n");
            Console.Write("QUERY 4: \n");
            var listOf = GetProductList();
            var items =
                //0
                from x in listOf
                //1
                where (x.ProductID > 0 && x.ProductID < 70)
                //2
                where (x.ProductName.Contains("a"))
                //3
                where (x.UnitPrice > 10)
                //4
                where (x.UnitsInStock < 100)
                //5
                where (x.UnitsInStock != 0)
                //6
                where (x.Category != "Condiments")
                //6&7
                group x by x.Category into g
                //8&9
                orderby g.Key ascending
                //10
                select g;
            foreach (var x in items)
            {
                Console.Write("\n");
                Console.Write("Category that survived our complex query: {0}", x.Key);
                Console.Write("\n");
            }

        }
        // The following code was provided by the instructor.
        public static List<Product> GetProductList()
        {
            List<Product> productList = new List<Product>
           {
                new Product{ ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 39 },
                new Product{ ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
                new Product{ ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
                new Product{ ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
                new Product{ ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.3500M, UnitsInStock = 0 },
                new Product{ ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.0000M, UnitsInStock = 120 },
                new Product{ ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.0000M, UnitsInStock = 15 },
                new Product{ ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.0000M, UnitsInStock = 6 },
                new Product{ ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.0000M, UnitsInStock = 29 },
                new Product{ ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.0000M, UnitsInStock = 31 },
                new Product{ ProductID = 11, ProductName = "Queso Cabrales", Category = "Dairy Products", UnitPrice = 21.0000M, UnitsInStock = 22 },
                new Product{ ProductID = 12, ProductName = "Queso Manchego La Pastora", Category = "Dairy Products", UnitPrice = 38.0000M, UnitsInStock = 86 },
                new Product{ ProductID = 13, ProductName = "Konbu", Category = "Seafood", UnitPrice = 6.0000M, UnitsInStock = 24 },
                new Product{ ProductID = 14, ProductName = "Tofu", Category = "Produce", UnitPrice = 23.2500M, UnitsInStock = 35 },
                new Product{ ProductID = 15, ProductName = "Genen Shouyu", Category = "Condiments", UnitPrice = 15.5000M, UnitsInStock = 39 },
                new Product{ ProductID = 16, ProductName = "Pavlova", Category = "Confections", UnitPrice = 17.4500M, UnitsInStock = 29 },
                new Product{ ProductID = 17, ProductName = "Alice Mutton", Category = "Meat/Poultry", UnitPrice = 39.0000M, UnitsInStock = 0 },
                new Product{ ProductID = 18, ProductName = "Carnarvon Tigers", Category = "Seafood", UnitPrice = 62.5000M, UnitsInStock = 42 },
                new Product{ ProductID = 19, ProductName = "Teatime Chocolate Biscuits", Category = "Confections", UnitPrice = 9.2000M, UnitsInStock = 25 },
                new Product{ ProductID = 20, ProductName = "Sir Rodney's Marmalade", Category = "Confections", UnitPrice = 81.0000M, UnitsInStock = 40 },
                new Product{ ProductID = 21, ProductName = "Sir Rodney's Scones", Category = "Confections", UnitPrice = 10.0000M, UnitsInStock = 3 },
                new Product{ ProductID = 22, ProductName = "Gustaf's Knäckebröd", Category = "Grains/Cereals", UnitPrice = 21.0000M, UnitsInStock = 104 },
                new Product{ ProductID = 23, ProductName = "Tunnbröd", Category = "Grains/Cereals", UnitPrice = 9.0000M, UnitsInStock = 61 },
                new Product{ ProductID = 24, ProductName = "Guaraná Fantástica", Category = "Beverages", UnitPrice = 4.5000M, UnitsInStock = 20 },
                new Product{ ProductID = 25, ProductName = "NuNuCa Nuß-Nougat-Creme", Category = "Confections", UnitPrice = 14.0000M, UnitsInStock = 76 },
                new Product{ ProductID = 26, ProductName = "Gumbär Gummibärchen", Category = "Confections", UnitPrice = 31.2300M, UnitsInStock = 15 },
                new Product{ ProductID = 27, ProductName = "Schoggi Schokolade", Category = "Confections", UnitPrice = 43.9000M, UnitsInStock = 49 },
                new Product{ ProductID = 28, ProductName = "Rössle Sauerkraut", Category = "Produce", UnitPrice = 45.6000M, UnitsInStock = 26 },
                new Product{ ProductID = 29, ProductName = "Thüringer Rostbratwurst", Category = "Meat/Poultry", UnitPrice = 123.7900M, UnitsInStock = 0 },
                new Product{ ProductID = 30, ProductName = "Nord-Ost Matjeshering", Category = "Seafood", UnitPrice = 25.8900M, UnitsInStock = 10 },
                new Product{ ProductID = 31, ProductName = "Gorgonzola Telino", Category = "Dairy Products", UnitPrice = 12.5000M, UnitsInStock = 0 },
                new Product{ ProductID = 32, ProductName = "Mascarpone Fabioli", Category = "Dairy Products", UnitPrice = 32.0000M, UnitsInStock = 9 },
                new Product{ ProductID = 33, ProductName = "Geitost", Category = "Dairy Products", UnitPrice = 2.5000M, UnitsInStock = 112 },
                new Product{ ProductID = 34, ProductName = "Sasquatch Ale", Category = "Beverages", UnitPrice = 14.0000M, UnitsInStock = 111 },
                new Product{ ProductID = 35, ProductName = "Steeleye Stout", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 20 },
                new Product{ ProductID = 36, ProductName = "Inlagd Sill", Category = "Seafood", UnitPrice = 19.0000M, UnitsInStock = 112 },
                new Product{ ProductID = 37, ProductName = "Gravad lax", Category = "Seafood", UnitPrice = 26.0000M, UnitsInStock = 11 },
                new Product{ ProductID = 38, ProductName = "Côte de Blaye", Category = "Beverages", UnitPrice = 263.5000M, UnitsInStock = 17 },
                new Product{ ProductID = 39, ProductName = "Chartreuse verte", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 69 },
                new Product{ ProductID = 40, ProductName = "Boston Crab Meat", Category = "Seafood", UnitPrice = 18.4000M, UnitsInStock = 123 },
                new Product{ ProductID = 41, ProductName = "Jack's New England Clam Chowder", Category = "Seafood", UnitPrice = 9.6500M, UnitsInStock = 85 },
                new Product{ ProductID = 42, ProductName = "Singaporean Hokkien Fried Mee", Category = "Grains/Cereals", UnitPrice = 14.0000M, UnitsInStock = 26 },
                new Product{ ProductID = 43, ProductName = "Ipoh Coffee", Category = "Beverages", UnitPrice = 46.0000M, UnitsInStock = 17 },
                new Product{ ProductID = 44, ProductName = "Gula Malacca", Category = "Condiments", UnitPrice = 19.4500M, UnitsInStock = 27 },
                new Product{ ProductID = 45, ProductName = "Rogede sild", Category = "Seafood", UnitPrice = 9.5000M, UnitsInStock = 5 },
                new Product{ ProductID = 46, ProductName = "Spegesild", Category = "Seafood", UnitPrice = 12.0000M, UnitsInStock = 95 },
                new Product{ ProductID = 47, ProductName = "Zaanse koeken", Category = "Confections", UnitPrice = 9.5000M, UnitsInStock = 36 },
                new Product{ ProductID = 48, ProductName = "Chocolade", Category = "Confections", UnitPrice = 12.7500M, UnitsInStock = 15 },
                new Product{ ProductID = 49, ProductName = "Maxilaku", Category = "Confections", UnitPrice = 20.0000M, UnitsInStock = 10 },
                new Product{ ProductID = 50, ProductName = "Valkoinen suklaa", Category = "Confections", UnitPrice = 16.2500M, UnitsInStock = 65 },
                new Product{ ProductID = 51, ProductName = "Manjimup Dried Apples", Category = "Produce", UnitPrice = 53.0000M, UnitsInStock = 20 },
                new Product{ ProductID = 52, ProductName = "Filo Mix", Category = "Grains/Cereals", UnitPrice = 7.0000M, UnitsInStock = 38 },
                new Product{ ProductID = 53, ProductName = "Perth Pasties", Category = "Meat/Poultry", UnitPrice = 32.8000M, UnitsInStock = 0 },
                new Product{ ProductID = 54, ProductName = "Tourtière", Category = "Meat/Poultry", UnitPrice = 7.4500M, UnitsInStock = 21 },
                new Product{ ProductID = 55, ProductName = "Pâté chinois", Category = "Meat/Poultry", UnitPrice = 24.0000M, UnitsInStock = 115 },
                new Product{ ProductID = 56, ProductName = "Gnocchi di nonna Alice", Category = "Grains/Cereals", UnitPrice = 38.0000M, UnitsInStock = 21 },
                new Product{ ProductID = 57, ProductName = "Ravioli Angelo", Category = "Grains/Cereals", UnitPrice = 19.5000M, UnitsInStock = 36 },
                new Product{ ProductID = 58, ProductName = "Escargots de Bourgogne", Category = "Seafood", UnitPrice = 13.2500M, UnitsInStock = 62 },
                new Product{ ProductID = 59, ProductName = "Raclette Courdavault", Category = "Dairy Products", UnitPrice = 55.0000M, UnitsInStock = 79 },
                new Product{ ProductID = 60, ProductName = "Camembert Pierrot", Category = "Dairy Products", UnitPrice = 34.0000M, UnitsInStock = 19 },
                new Product{ ProductID = 61, ProductName = "Sirop d'érable", Category = "Condiments", UnitPrice = 28.5000M, UnitsInStock = 113 },
                new Product{ ProductID = 62, ProductName = "Tarte au sucre", Category = "Confections", UnitPrice = 49.3000M, UnitsInStock = 17 },
                new Product{ ProductID = 63, ProductName = "Vegie-spread", Category = "Condiments", UnitPrice = 43.9000M, UnitsInStock = 24 },
                new Product{ ProductID = 64, ProductName = "Wimmers gute Semmelknödel", Category = "Grains/Cereals", UnitPrice = 33.2500M, UnitsInStock = 22 },
                new Product{ ProductID = 65, ProductName = "Louisiana Fiery Hot Pepper Sauce", Category = "Condiments", UnitPrice = 21.0500M, UnitsInStock = 76 },
                new Product{ ProductID = 66, ProductName = "Louisiana Hot Spiced Okra", Category = "Condiments", UnitPrice = 17.0000M, UnitsInStock = 4 },
                new Product{ ProductID = 67, ProductName = "Laughing Lumberjack Lager", Category = "Beverages", UnitPrice = 14.0000M, UnitsInStock = 52 },
                new Product{ ProductID = 68, ProductName = "Scottish Longbreads", Category = "Confections", UnitPrice = 12.5000M, UnitsInStock = 6 },
                new Product{ ProductID = 69, ProductName = "Gudbrandsdalsost", Category = "Dairy Products", UnitPrice = 36.0000M, UnitsInStock = 26 },
                new Product{ ProductID = 70, ProductName = "Outback Lager", Category = "Beverages", UnitPrice = 15.0000M, UnitsInStock = 15 },
                new Product{ ProductID = 71, ProductName = "Flotemysost", Category = "Dairy Products", UnitPrice = 21.5000M, UnitsInStock = 26 },
                new Product{ ProductID = 72, ProductName = "Mozzarella di Giovanni", Category = "Dairy Products", UnitPrice = 34.8000M, UnitsInStock = 14 },
                new Product{ ProductID = 73, ProductName = "Röd Kaviar", Category = "Seafood", UnitPrice = 15.0000M, UnitsInStock = 101 },
                new Product{ ProductID = 74, ProductName = "Longlife Tofu", Category = "Produce", UnitPrice = 10.0000M, UnitsInStock = 4 },
                new Product{ ProductID = 75, ProductName = "Rhönbräu Klosterbier", Category = "Beverages", UnitPrice = 7.7500M, UnitsInStock = 125 },
                new Product{ ProductID = 76, ProductName = "Lakkalikööri", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 57 },
                new Product{ ProductID = 77, ProductName = "Original Frankfurter grüne Soße", Category = "Condiments", UnitPrice = 13.0000M, UnitsInStock = 32 }
            };
            return productList;
        }
        // END of code provided by the instructor.
    }
}
