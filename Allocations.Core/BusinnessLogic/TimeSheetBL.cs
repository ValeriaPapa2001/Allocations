using Allocations.Core.Entities;
using Allocations.Core.Exceptions;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.BusinnessLogic
{
    public class TimeSheetBL : ITimeSheetBL

    {
        private readonly ITimeSheetRepository _timeSheetRepository;
        public TimeSheetBL(ITimeSheetRepository timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
        }

        public async Task<IEnumerable<TimeSheet>> GetAllTimeSheetsAsync()
        {
            return await _timeSheetRepository.FetchAsync();
        }

        public async Task<IEnumerable<TimeSheet>> GetAllTimeSheetsDetailedAsync()
        {
            return await _timeSheetRepository.GetAllTimeSheetsDetailedAsync();
        }

        public Task<TimeSheet> GetTimeSheetDetailedAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TimeSheet> GetTimeSheetsByIdAsync(int id)
        {
            return await _timeSheetRepository.GetByIdAsync(id);
        }

        public async Task<CudResult> InsertTimeSheetAsync(TimeSheet timeSheet)
        {
            if(timeSheet.HourActivity.TotalHours > MaxWorkTimeReached.maxHour)
            {
                //TODO controllare che timeSheet.Employee NON sia NULL
                var timeSheetDetailed = await _timeSheetRepository.GetTimeSheetDetailedAsync(timeSheet.Id);

                throw new MaxWorkTimeReached(timeSheetDetailed.Employee);
            }

            var totalHours = _timeSheetRepository.FetchAsync(x => x.StartActivity == timeSheet.StartActivity
                                                    && x.IdEmployee == timeSheet.IdEmployee)
                                                    .Result
                                                    .Sum(x => x.HourActivity.TotalHours);        
            if(totalHours > MaxWorkTimeReached.maxHour)
            {
                //TODO controllare che timeSheet.Employee NON sia NULL
                var timeSheetDetailed = await _timeSheetRepository.GetTimeSheetDetailedAsync(timeSheet.Id);

                throw new MaxWorkTimeReached(timeSheetDetailed.Employee);
            }

            return await _timeSheetRepository.InsertAsync(timeSheet);
        }

        public async Task<CudResult> UpdateTimeSheetAsync(TimeSheet timeSheet)
        {
            if (timeSheet.HourActivity.TotalHours > MaxWorkTimeReached.maxHour)
            {
                //TODO controllare che timeSheet.Employee NON sia NULL
                var timeSheetDetailed = await _timeSheetRepository.GetTimeSheetDetailedAsync(timeSheet.Id);

                throw new MaxWorkTimeReached(timeSheetDetailed.Employee);
            }

            var totalHours = _timeSheetRepository.FetchAsync(x => x.StartActivity == timeSheet.StartActivity
                                                    && x.IdEmployee == timeSheet.IdEmployee)
                                                    .Result
                                                    .Sum(x => x.HourActivity.TotalHours);
            if (totalHours > MaxWorkTimeReached.maxHour)
            {
                //TODO controllare che timeSheet.Employee NON sia NULL
                var timeSheetDetailed = await _timeSheetRepository.GetTimeSheetDetailedAsync(timeSheet.Id);

                throw new MaxWorkTimeReached(timeSheetDetailed.Employee);
            }

            return await _timeSheetRepository.UpdateAsync(timeSheet);
        }
    }
}
