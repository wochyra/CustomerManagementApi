using CustomerManagementApi.Interfaces;
using CustomerManagementApi.Models;
using System.Xml.Linq;

namespace CustomerManagementApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new ();
        private int _nextId = 1;


        public IEnumerable<Customer> GetAll() => _customers;

        public Customer? GetById(int id) => _customers.FirstOrDefault(c => c.Id == id);

        public Customer Create(Customer customer)
        {
            customer.Id = _nextId++;
            _customers.Add(customer);
            return customer;
        }

        public bool Update(int id, Customer updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Firstname = updated.Firstname;
            existing.Surname = updated.Surname;
            return true;
        }

        public bool Delete(int id)
        {
            var customer = GetById(id);
            return customer != null && _customers.Remove(customer);
        }
    }
}
