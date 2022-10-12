
using Allocations.Lib;
using Allocations.Mvc.DataContracts;
using Newtonsoft.Json;
using ServiceReference1;
using System.Net.Http;

namespace Allocations.Mvc.Utils
{
    public class WcfClient
    {
        private readonly CustomerServiceClient _client;

        public WcfClient()
        {
            _client = new CustomerServiceClient();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {

            var customers = _client.GetAllCustomersAsync().Result.Select( c => new Customer
            {
                Id = c.Id,
                Name = c.Name,
                City = c.City,
                Region = c.Region,
                Province = c.Province,
                Dimension = c.Dimension,
            });
            return customers;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _client.GetCustomerAsync(id);
            var customerContract = new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                City = customer.City,
                Region = customer.Region,
                Province = customer.Province,
                Dimension = customer.Dimension,
            };
            return customerContract;
        }

        public async Task<CudResultContract> InsertCustomer(Customer customer)
        {            
            var result = await _client.InsertCustomerAsync(customer);
            return new CudResultContract
            {
                Message = result
            };
        }

        public async Task<CudResultContract> UpdateCustomer(Customer customer)
        {
            var result = await _client.UpdateCustomerAsync(customer);
            return new CudResultContract
            {
                Message = result
            };
        }

        public async Task<CudResultContract> DeleteCustomer(int id)
        {
            var result = await _client.DeleteCustomerAsync(id);
            return new CudResultContract
            {
                Message = result
            };
        }



    }
}
