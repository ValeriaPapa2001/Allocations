using Allocations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Mock
{
    public class TimeSheetStorage
    {
        public static List<TimeSheet> TimeSheets { get; set; }
        public static void Initialize()
        {
            TimeSheets = new List<TimeSheet>();
            TimeSheets.Add(new TimeSheet
            {
                Id = 1,
                StartActivity = DateTime.Now,
                HourActivity = DateTime.Now.AddHours(2)-DateTime.Now,
                IdActivity = 1,
                IdCustomer =1,
                IdEmployee =1,
                IdJob =1,
             });

            TimeSheets.Add(new TimeSheet
            {
                Id = 2,
                StartActivity = DateTime.Now.AddDays(-2),
                HourActivity = DateTime.Now.AddDays(-2).AddHours(2) - DateTime.Now.AddDays(-2),
                IdActivity = 1,
                IdCustomer = 1,
                IdEmployee = 1,
                IdJob = 1,
            });


            TimeSheets.Add(new TimeSheet
            {
                Id = 3,
                StartActivity = DateTime.Now.AddMonths(-1),
                HourActivity = DateTime.Now.AddMonths(-2).AddHours(2) - DateTime.Now.AddMonths(-1),
                IdActivity = 1,
                IdCustomer = 1,
                IdEmployee = 1,
                IdJob = 1,
            });

        }
    }
}
