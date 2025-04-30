using CustomerManagementApi.Models;
using CustomerManagementApi.Services;

namespace CustomerManagementApi.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void Create_ShouldAssignIdAndAddCustomer()
        {
            // Arrange
            var service = new CustomerService();
            var customer = new Customer { Firstname = "John", Surname = "Doe" };

            // Act
            var created = service.Create(customer);

            // Assert
            Assert.Equal(1, created.Id);
            Assert.Equal("John", created.Firstname);
            Assert.Equal("Doe", created.Surname);
        }

        [Fact]
        public void GetAll_ShouldReturnAllCustomers()
        {
            // Arrange
            var service = new CustomerService();
            service.Create(new Customer { Firstname = "A", Surname = "B" });
            service.Create(new Customer { Firstname = "C", Surname = "D" });

            // Act
            var result = service.GetAll().ToList();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetById_ShouldReturnCorrectCustomer()
        {
            // Arrange
            var service = new CustomerService();
            var customer = service.Create(new Customer { Firstname = "Alice", Surname = "Smith" });

            // Act
            var result = service.GetById(customer.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Alice", result!.Firstname);
        }

        [Fact]
        public void Update_ShouldModifyCustomer_WhenExists()
        {
            // Arrange
            var service = new CustomerService();
            var original = service.Create(new Customer { Firstname = "Bob", Surname = "Old" });
            var updated = new Customer { Firstname = "Bob", Surname = "New" };

            // Act
            var success = service.Update(original.Id, updated);
            var result = service.GetById(original.Id);

            // Assert
            Assert.True(success);
            Assert.Equal("New", result!.Surname);
        }

        [Fact]
        public void Update_ShouldReturnFalse_WhenCustomerNotFound()
        {
            // Arrange
            var service = new CustomerService();
            var updated = new Customer { Firstname = "Ghost", Surname = "None" };

            // Act
            var success = service.Update(999, updated);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void Delete_ShouldRemoveCustomer_WhenExists()
        {
            // Arrange
            var service = new CustomerService();
            var customer = service.Create(new Customer { Firstname = "Delete", Surname = "Me" });

            // Act
            var deleted = service.Delete(customer.Id);
            var result = service.GetById(customer.Id);

            // Assert
            Assert.True(deleted);
            Assert.Null(result);
        }

        [Fact]
        public void Delete_ShouldReturnFalse_WhenCustomerNotFound()
        {
            // Arrange
            var service = new CustomerService();

            // Act
            var deleted = service.Delete(999);

            // Assert
            Assert.False(deleted);
        }
    }
}