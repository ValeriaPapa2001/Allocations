using Allocations.Core.BusinnessLogic;
using Allocations.Core.Ef;
using Allocations.Core.Ef.Repositories;
using Allocations.Core.Entities;
using Allocations.Core.Interfaces;
using Allocations.Lib;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerBL _logic;
        public CustomerService()
        {
            var services = new ServiceCollection()
                 .AddTransient<AllocationsDbContext>()
                 .AddTransient<ICustomerBL, CustomerBL>()
                 .AddTransient<ICustomerRepository, EFCustomerRepository>()
                 .BuildServiceProvider();

            _logic = services.GetService<ICustomerBL>();
        }

        public async Task<string> DeleteCustomerAsync(int id)
        {
            var result = await _logic.DeleteCustomerAsync(id);
            return result.Message;
        }

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            return (await _logic.GetAllCustomersAsync()).ToList();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _logic.GetCustomerByIdAsync(id);
        }

        public async Task<string> InsertCustomerAsync(Customer customer)
        {
            var result = await _logic.InsertCustomerAsync(customer);
            return result.Message;
        }

        public async Task<string> UpdateCustomerAsync(Customer customer)
        {
            var result = await _logic.UpdateCustomerAsync(customer);
            return result.Message;
        }
    }
}
