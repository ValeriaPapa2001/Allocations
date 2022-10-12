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

        public async Task<TimeSheet> GetTimeSheetDetailedAsync(int id)
        {
            return await _context.TimeSheets.Where(t => t.Id == id).Include(t => t.Employee).FirstOrDefaultAsync();

        }
    }
}
