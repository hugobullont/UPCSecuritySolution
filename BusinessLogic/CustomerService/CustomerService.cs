using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccess.CustomerRepository;

namespace BusinessLogic.CustomerService
{
    public class CustomerService : ICustomerService
    {
        public List<Customer> GetAllCustomers()
        {
            ICustomerRepository repository = new CustomerRepository();
            return repository.GetAllCustomers();
        }


        public void InsertCustomer(Customer objcustomer)
        {
            ICustomerRepository repository = new CustomerRepository();
            repository.InsertCustomer(objcustomer);
        }
    }
}
