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

            Employees.Add(new Employee
            {
                Id = 4,
                FirstName = "Giacomo",
                LastName = "Rosa",
                BirthDate = DateTime.Parse("1988-10-10"),
                HourCost = decimal.Parse("350"),
                Email = "jack@ad.it",
                StartDate = DateTime.Parse("2022-10-31"),
                IdRole = 4,
            });

            Employees.Add(new Employee
            {
                Id = 4,
                FirstName = "Luigi",
                LastName = "Gialli",
                BirthDate = DateTime.Parse("2001-11-10"),
                HourCost = decimal.Parse("24"),
                Email = "g@g.it",
                StartDate = DateTime.Parse("2022-11-31"),
                IdRole = 1,
            });
            Employees.Add(new Employee
            {
                Id = 5,
                FirstName = "Simonetta",
                LastName = "Davi",
                BirthDate = DateTime.Parse("1971-08-10"),
                HourCost = decimal.Parse("54"),
                Email = "s@d.it",
                StartDate = DateTime.Parse("1997-12-31"),
                IdRole = 4,
            });

            Employees.Add(new Employee
            {
                Id = 6,
                FirstName = "Gianluca",
                LastName = "Fiore",
                BirthDate = DateTime.Parse("1997-03-29"),
                HourCost = decimal.Parse("56"),
                Email = "g@f.it",
                StartDate = DateTime.Parse("2019-04-03"),
                IdRole = 4,
            });

            Employees.Add(new Employee
            {
                Id = 7,
                FirstName = "Beppe",
                LastName = "Donati",
                BirthDate = DateTime.Parse("1963-10-02"),
                HourCost = decimal.Parse("300"),
                Email = "b@d.it",
                StartDate = DateTime.Parse("1988-12-31"),
                IdRole = 4,
            });

            Employees.Add(new Employee
            {
                Id = 8,
                FirstName = "Eliana",
                LastName = "Casoldi",
                BirthDate = DateTime.Parse("1987-06-07"),
                HourCost = decimal.Parse("100"),
                Email = "e@c.it",
                StartDate = DateTime.Parse("2006-12-31"),
                IdRole = 2,
            });

            Employees.Add(new Employee
            {
                Id = 9,
                FirstName = "Amanda",
                LastName = "Cabrini",
                BirthDate = DateTime.Parse("1978-06-07"),
                HourCost = decimal.Parse("150"),
                Email = "a@c.it",
                StartDate = DateTime.Parse("1990-12-31"),
                IdRole = 1,
            });

            Employees.Add(new Employee
            {
                Id = 10,
                FirstName = "Stefania",
                LastName = "Canali",
                BirthDate = DateTime.Parse("1995-06-07"),
                HourCost = decimal.Parse("60"),
                Email = "s@c.it",
                StartDate = DateTime.Parse("2011-12-31"),
                IdRole = 5,
            });



        }
    }
}
