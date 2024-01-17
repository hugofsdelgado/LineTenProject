using LineTen.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineTen.Application.Interface
{
  public interface ICustomerService
  {
    List<Customer> GetCustomers();
    Customer CreateCustomer(string name, string lastname, string phone, string email);
    Customer UpdateCustomer(int id, string name, string lastname, string phone, string email);
    Customer DeleteCustomer(int id);

  }
}
