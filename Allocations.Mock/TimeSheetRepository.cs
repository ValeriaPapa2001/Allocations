using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Mock
{
    public class TimeSheetRepository:ITimeSheetRepository
    {
        public async Task<CudResult> DeleteAsync(object id)
        {
            var timeSheet = await GetByIdAsync(id);
            TimeSheetStorage.TimeSheets.Remove(timeSheet);
            return new CudResult();
        }

        public async Task<IEnumerable<TimeSheet>> FetchAsync(Func<TimeSheet, bool> filter = null)
        {
            return TimeSheetStorage.TimeSheets.Where(filter).ToList();

        }

      

        public async Task<TimeSheet> GetByIdAsync(object id)
        {
            return TimeSheetStorage.TimeSheets.FirstOrDefault(e => e.Id == (int)id);
        }

        public async Task<TimeSheet> GetTimeSheetDetailedAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CudResult> InsertAsync(TimeSheet entity)
        {
            int newId = TimeSheetStorage.TimeSheets.Max(x => x.Id) + 1;
            entity.Id = newId;
            TimeSheetStorage.TimeSheets.Add(entity);
            return new CudResult();
        }

        public async Task<CudResult> UpdateAsync(TimeSheet entity)
        {
            var timeSheet = TimeSheetStorage.TimeSheets.FirstOrDefault(x => x.Id == entity.Id);
            TimeSheetStorage.TimeSheets.Remove(timeSheet);
            TimeSheetStorage.TimeSheets.Add(entity);
            return new CudResult();
        }
    }
}
