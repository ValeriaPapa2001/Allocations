using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.BusinnessLogic
{
    public class CustomerBL : ICustomerBL
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBL(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CudResult> DeleteCustomerAsync(int id)
        {
            return await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.FetchAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<CudResult> InsertCustomerAsync(Customer customer)
        {
            return await _customerRepository.InsertAsync(customer);
        }

        public async Task<CudResult> UpdateCustomerAsync(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }
    }
}
