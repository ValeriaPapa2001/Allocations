using Allocations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Mock
{
    public class EmployeeStorage
    {
        public static List<Employee> Employees { get; set; }
        public static void Initialize()
        {
            Employees = new List<Employee>();
            Employees.Add(new Employee
            {
                Id = 1,
                FirstName = "Tizio",
                LastName = "Caio",
                BirthDate = DateTime.Now,
                HourCost = 30,
                Email = "tizio@caio.com",
                StartDate = DateTime.Now,
                IdRole = 1,
            });

            Employees.Add(new Employee
            {
                Id = 2,
                FirstName = "Pippo",
                LastName = "Pluto",
                BirthDate = DateTime.Parse("1990-10-10"),
                HourCost = decimal.Parse("30.8"),
                Email = "p@p.it",
                StartDate = DateTime.Parse("2020-10-10"),
                IdRole = 2,
            });

            Employees.Add(new Employee
            {
                Id = 3,
                FirstName = "12jksf",
                LastName = "abc&/",
                BirthDate = DateTime.Parse("1910-10-10"),
                HourCost = decimal.Parse("300.8"),
                Email = "p@p.it",
                StartDate = DateTime.Parse("2022-12-31"),
                IdRole = 3,
            });
        }
    }
}
