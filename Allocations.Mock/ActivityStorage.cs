using Allocations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Allocations.Core.Mock
{
    public class ActivityStorage
    {
        public static List<Activity> Activities { get; set; }
        public static void Initialize()
        {
            Activities = new List<Activity>();

            Activities.Add(new Activity
            {
                Id = 1,
                Description = "Front-end",
            });

            Activities.Add(new Activity
            {
                Id = 2,
                Description = "Back-end",
            });

            Activities.Add(new Activity
            {
                Id = 3,
                Description = "Full stack"
            });

            Activities.Add(new Activity
            {
                Id = 4,
                Description = "Mobile system"
            });
            Activities.Add(new Activity
            {
                Id = 5,
                Description = "Cloud system"
            });
        }
    }
}
