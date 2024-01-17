using LineTen.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LineTen.Application.Interface
{
  public class CustomerService : ICustomerService
  {
    private readonly ICustomerRepository customerRepository;
    public CustomerService(ICustomerRepository customerRepository)
    {
      this.customerRepository = customerRepository;
    }

    public Customer CreateCustomer(string name, string lastname, string phone, string email)
    {
      return this.customerRepository.CreateCustomer(name, lastname, phone, email);
    }

    public Customer DeleteCustomer(int id)
    {
      return this.customerRepository.DeleteCustomer(id);
    }

    public Customer UpdateCustomer(int id, string name, string lastname, string phone, string email)
    {
      return this.customerRepository.UpdateCustomer(id, name, lastname, phone, email);
    }

    public List<Customer> GetCustomers()
    {
      return this.customerRepository.GetCustomers();
    }
  }
}
