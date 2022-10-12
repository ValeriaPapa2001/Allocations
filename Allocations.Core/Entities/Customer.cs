using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Entities
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string Dimension { get; set; }
        //[DataMember]
        public IList<TimeSheet> TimeSheets { get; set; }
    }
}
