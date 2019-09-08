using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lambdas_and_Linq
{
    class App
    {
        public void Run()
        {
            new Classwork().Run();
            var luke = new Customer();
            var luke2 = new Customer(124, "Luke2");
            var luke3 = new Customer(125, "Luke3");
            ToDictionary(luke, luke2, luke3);

        }
        public void ToDictionary(Customer luke, Customer luke2, Customer luke3)
        {
            
            List<Customer> customersList = new List<Customer>() { luke, luke2, luke3 };

            Dictionary<int, Customer> customers = customersList.ToDictionary(c => c.CustomerID);

            Console.WriteLine("LINQ customers to list");
            foreach (var item in customers)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value.name);
            }

        }
    }

    class Customer
    {
        public int CustomerID;
        public string name;
        int Cost;


        public Customer(int id = 123, string name = "Luke")
        {
            this.name = name;
            CustomerID = id;
        }
    }
}
