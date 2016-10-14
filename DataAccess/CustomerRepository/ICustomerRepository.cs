using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.CustomerRepository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();

        void InsertCustomer(Customer objcustomer);



    }
}
