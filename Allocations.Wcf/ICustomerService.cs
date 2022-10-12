using Allocations.Core.Entities;
using Allocations.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        Task<IList<Customer>> GetAllCustomersAsync();
        [OperationContract]
        Task<Customer> GetCustomerAsync(int id);
        [OperationContract]
        Task<string> InsertCustomerAsync(Customer customer);
        [OperationContract]
        Task<string> UpdateCustomerAsync(Customer customer);
        [OperationContract]
        Task<string> DeleteCustomerAsync(int id);


    }
}
