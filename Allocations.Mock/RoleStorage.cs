using Allocations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Allocations.Core.Mock
{
    public class RoleStorage
    {
        public static List<Role> Roles { get; set; }
        public static void Initialize()
        {
            Roles = new List<Role>();

            Roles.Add(new Role
            {
                Id = 1,
                Description = "Software Developer",
            });

            Roles.Add(new Role
            {
                Id = 2,
                Description = "Data Analyst",
            });

            Roles.Add(new Role
            {
                Id = 3,
                Description = "Solutions Architect"
            });

            Roles.Add(new Role
            {
                Id = 4,
                Description = "System Analyst"
            });
            Roles.Add(new Role
            {
                Id = 5,
                Description = "Cloud Engineer"
            });
        }
    }
}
