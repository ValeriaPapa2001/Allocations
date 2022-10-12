using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Lib.Interfaces
{
    public interface IRepositoryAsync<T>
    {
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> FetchAsync(Func<T, bool> filter = null);
        Task<CudResult> InsertAsync(T entity);
        Task<CudResult> UpdateAsync(T entity);
        Task<CudResult> DeleteAsync(object id);


    }
}
