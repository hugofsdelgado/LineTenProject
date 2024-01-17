using LineTen.Application.Interface;
using LineTen.Domain.Entitites;
using LineTen.Infrastructure.Context;

namespace LineTen.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        public static List<Customer> lstCustomers = new List<Customer>()
        {
            new Customer(1,"Name1", "Last1", "+351123456789", "test@test.com" )
        };

        public Customer CreateCustomer(string name, string lastname, string phone, string email)
        {
            Customer Customer;
            try
            {
                using (var contxt = new LineTenContext())
                {
                    Customer = new Customer(name, lastname, phone, email);

                    contxt.Customers.Add(Customer);
                    contxt.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Customer;
        }

        public Customer DeleteCustomer(int id)
        {
            Customer Customers;
            using (var contxt = new LineTenContext())
            {
                Customers = contxt.Customers.Where(x => x.Id == id).FirstOrDefault();

                if (Customers != null)
                {
                    contxt.Customers.Remove(Customers);
                    contxt.SaveChanges();
                }
                else
                {
                    throw new Exception("No Customer found for the id.");
                }
            }
            return Customers;
        }


        public List<Customer> GetCustomers()
        {
            List<Customer> lst = new List<Customer>();
            using (var contxt = new LineTenContext())
            {
                var query = from CustomerTable in contxt.Customers
                            orderby CustomerTable.Id
                            select CustomerTable;

                lst = query.ToList();

            }
            return lst;
        }

        public Customer UpdateCustomer(int id, string? name, string? lastname, string? phone, string? email)
        {
            Customer Customers;
            using (var contxt = new LineTenContext())
            {
                Customers = contxt.Customers.Where(x => x.Id == id).FirstOrDefault();

                if (Customers != null)
                {
                    Customers.FirstName = !string.IsNullOrEmpty(name) && Customers.FirstName != name ? name : Customers.FirstName;
                    Customers.LastName = !string.IsNullOrEmpty(lastname) && Customers.LastName != lastname ? lastname : Customers.LastName;
                    Customers.Phone = !string.IsNullOrEmpty(phone) && Customers.Phone != phone ? phone : Customers.Phone;
                    Customers.Email = !string.IsNullOrEmpty(email) && Customers.Email != email ? email : Customers.Email;
                    contxt.SaveChanges();
                }
                else
                {
                    throw new Exception("No Customer found for the id.");
                }
            }
            return Customers;
        }


        public Customer GetCustomerByName(string name)
        {
            Customer customer = new Customer();

            using (var contxt = new LineTenContext())
            {
                var query = from CustomerTable in contxt.Customers
                            where CustomerTable.FirstName == name
                            orderby CustomerTable.Id
                            select CustomerTable;

                customer = query.FirstOrDefault();
            }

            if (customer == null)
            {
                throw new Exception($"Customer not found by the name {name}.");
            }

            return customer;

        }
    }
}
