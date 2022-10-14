using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Ef.Repositories
{
    public class EFTimeSheetRepository: EFRepositoryAsync<TimeSheet>, ITimeSheetRepository
    {
        private readonly AllocationsDbContext _context;
        public EFTimeSheetRepository(AllocationsDbContext context) : base(context, () => context.TimeSheets)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimeSheet>> GetAllTimeSheetsDetailedAsync(Func<TimeSheet, bool> filter = null)
        {
            if (filter != null)
            {
                return _context.TimeSheets.Include(x => x.Employee).Include(x => x.Job).Include(x => x.Customer).Include(x=>x.Activity).Where(filter).ToList();
            }
            return await _context.TimeSheets.Include(x => x.Employee).Include(x => x.Job).Include(x => x.Customer).Include(x=>x.Activity).ToListAsync();
        }

        public async Task<TimeSheet> GetTimeSheetDetailedAsync(int id)
        {
            return await _context.TimeSheets.Where(t => t.Id == id).Include(t => t.Employee).FirstOrDefaultAsync();

        }
    }
}
