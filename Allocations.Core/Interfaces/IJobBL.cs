using Allocations.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Interfaces
{
    public interface IJobBL
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
    }
}
