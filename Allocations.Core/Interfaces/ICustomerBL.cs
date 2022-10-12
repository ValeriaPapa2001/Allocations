using Allocations.Core.Entities;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Interfaces
{
    public interface ICustomerBL
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<CudResult> UpdateCustomerAsync(Customer customer);
        Task<CudResult> DeleteCustomerAsync(int id);
        Task<CudResult> InsertCustomerAsync(Customer customer);
    }
}
