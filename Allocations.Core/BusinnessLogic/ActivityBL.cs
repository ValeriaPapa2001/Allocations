using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.BusinnessLogic
{
    public class ActivityBL : IActivityBL
    {
        private readonly IActivityRepository _activityRepo;
        public ActivityBL(IActivityRepository activityRepo)
        {
            _activityRepo = activityRepo;
        }

        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
        {
            return await _activityRepo.FetchAsync();
        }
    }
}
