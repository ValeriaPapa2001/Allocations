using Allocations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Mock
{
    public class CustomerStorage
    {
        public static List<Customer> Customers { get; set; }
        public static void Initialize()
        {
            Customers = new List<Customer>();
            Customers.Add(new Customer
            {
                Id = 1,
                Name = "Tizio",
                City = "Bolo",
                Province = "BO",
                Region = "Emilia Romagna",
                Dimension = "Enterprise",
            });

            Customers.Add(new Customer
            {
                Id = 2,
                Name = "Sempronio",
                City = "Ferrara",
                Province = "FE",
                Region = "Emilia Romagna",
                Dimension = "Small",
            });


        }
    }
}
