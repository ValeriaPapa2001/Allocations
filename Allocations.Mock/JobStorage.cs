using Allocations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Allocations.Core.Mock
{
    public class JobStorage
    {

        public static List<Job> Jobs { get; set; }
        public static void Initialize()
        {
            Jobs = new List<Job>();

            Jobs.Add(new Job
            {
                Id = 1,
                Description = "Portale pubblico",
            });

            Jobs.Add(new Job
            {
                Id = 2,
                Description = "Applicazione Mobile",
            });

            Jobs.Add(new Job
            {
                Id = 3,
                Description = "Creazione Database"
            });

            Jobs.Add(new Job
            {
                Id = 4,
                Description = "Manutenzione"
            });
            Jobs.Add(new Job
            {
                Id = 5,
                Description = "Creazione software"
            });
        }
    }
}
