using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLogic.CustomerService
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();

        void InsertCustomer(Customer objcustomer);
    }
}
