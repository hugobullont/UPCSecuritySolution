using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Entities.Customer> GetAllCustomers()
        {
            UPCSecurityEntities UPCModel = new UPCSecurityEntities();
            List<Customer> customers = (from c in UPCModel.Customers
                                    select c).ToList();
            return customers;
        }


        public void InsertCustomer(Customer objcustomer)
        {
            using (var model = new UPCSecurityEntities())
            {
                model.Customers.Add(objcustomer);
                model.SaveChanges();
            }
        }
    }
}
