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
    public class CustomerRepository: ICustomerRepository
    {
        public async Task<CudResult> DeleteAsync(object id)
        {
            var customer = await GetByIdAsync(id);
            CustomerStorage.Customers.Remove(customer);
            return new CudResult();
        }

        public async Task<IEnumerable<Customer>> FetchAsync(Func<Customer, bool> filter = null)
        {
            return CustomerStorage.Customers.Where(filter).ToList();

        }

        public async Task<Customer> GetByIdAsync(object id)
        {
            return CustomerStorage.Customers.FirstOrDefault(e => e.Id == (int)id);
        }

        public async Task<CudResult> InsertAsync(Customer entity)
        {
            int newId = CustomerStorage.Customers.Max(x => x.Id) + 1;
            entity.Id = newId;
            CustomerStorage.Customers.Add(entity);
            return new CudResult();
        }

        public async Task<CudResult> UpdateAsync(Customer entity)
        {
            var customer = CustomerStorage.Customers.FirstOrDefault(x => x.Id == entity.Id);
            CustomerStorage.Customers.Remove(customer);
            CustomerStorage.Customers.Add(entity);
            return new CudResult();
        }
    }
}
