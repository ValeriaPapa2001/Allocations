using Allocations.Core.BusinnessLogic;
using Allocations.Core.Entities;
using Allocations.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Interfaces
{
    public interface ITimeSheetRepository: IRepositoryAsync<TimeSheet>
    {
        
        Task<IEnumerable<TimeSheet>> GetAllTimeSheetsDetailedAsync(Func<TimeSheet, bool> filter = null);
        Task<TimeSheet> GetTimeSheetDetailedAsync(int id);
    }
}
