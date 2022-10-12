using Allocations.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Allocations.Core.Entities;


namespace Allocations.Core.Interfaces
{
    public interface IJobRepository: IRepositoryAsync<Job>
    {
    }
}
