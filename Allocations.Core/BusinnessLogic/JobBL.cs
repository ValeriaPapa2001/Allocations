using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.BusinnessLogic
{
    public class JobBL : IJobBL
    {
        private readonly IJobRepository _jobRepository;
        public JobBL(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.FetchAsync();
        }
    }
}
