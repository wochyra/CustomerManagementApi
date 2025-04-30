using CustomerManagementApi.Models;

namespace CustomerManagementApi.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(int id);
        Customer Create(Customer customer);
        bool Update(int id, Customer customer);
        bool Delete(int id);
    }
}
