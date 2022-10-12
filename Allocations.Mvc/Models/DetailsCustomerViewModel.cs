using Allocations.Core.Entities;
using System.Runtime.Serialization;

namespace Allocations.Mvc.Models.CustomerModel

{

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string City { get; set; }

        public string Region { get; set; }
        public string Province { get; set; }

        public string Dimension { get; set; }


    }
}


