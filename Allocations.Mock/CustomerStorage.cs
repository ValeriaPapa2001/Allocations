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

            Customers.Add(new Customer
            {
                Id = 3,
                Name = "Tim",
                City = "Milano",
                Province = "MI",
                Region = "Lombardia",
                Dimension = "Enterprise",
            });

            Customers.Add(new Customer
            {
                Id = 4,
                Name = "Avanade",
                City = "Milano",
                Province = "MI",
                Region = "Lombardia",
                Dimension = "Enterprise",
            });

            Customers.Add(new Customer
            {
                Id = 5,
                Name = "Accenture",
                City = "Milano",
                Province = "MI",
                Region = "Lombardia",
                Dimension = "Enterprise",
            });

            Customers.Add(new Customer
            {
                Id = 6,
                Name = "Prima",
                City = "Torino",
                Province = "TO",
                Region = "Piemonte",
                Dimension = "Enterprise",
            });

            Customers.Add(new Customer
            {
                Id = 7,
                Name = "Electra",
                City = "Roma",
                Province = "RM",
                Region = "Lazio",
                Dimension = "Enterprise",
            });

            Customers.Add(new Customer
            {
                Id = 8,
                Name = "Amabile",
                City = "Bologna",
                Province = "BO",
                Region = "Emilia Romagna",
                Dimension = "Small",
            });

            Customers.Add(new Customer
            {
                Id = 9,
                Name = "Vodafone",
                City = "Milano",
                Province = "MI",
                Region = "Lombardia",
                Dimension = "Enterprise",
            });

            Customers.Add(new Customer
            {
                Id = 10,
                Name = "Eolo",
                City = "Milano",
                Province = "MI",
                Region = "Lombardia",
                Dimension = "Enterprise",
            });



        }
    }
}
