using Allocations.Core.Entities;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Interfaces
{
    public interface ITimeSheetBL
    {
        Task<IEnumerable<TimeSheet>> GetAllTimeSheetsAsync();
        Task<TimeSheet> GetTimeSheetsByIdAsync(int id);

        Task<CudResult> InsertTimeSheetAsync(TimeSheet timeSheet);
        Task<CudResult> UpdateTimeSheetAsync(TimeSheet timeSheet);
        
    }
}
