using CustomerAPI.DTOs;
using CustomerAPI.Interfaces;
using CustomerAPI.Models;

namespace CustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerResponseDto> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Address = dto.Address,
                Phone = dto.Phone,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _repository.CreateAsync(customer);
            return MapToResponse(created);
        }

        // fetching all customer

        public async Task<IEnumerable<CustomerResponseDto>> GetAllCustomerAsync()
        {
            var customers = await _repository.GetAllAsync();
            return customers.Select(MapToResponse);
        }

        // fetch customer by id 

        public async Task<CustomerResponseDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            return customer == null ? null : MapToResponse(customer);
        }

        private static CustomerResponseDto MapToResponse(Customer c) => new()
        {
            Id = c.Id,
            FullName = c.FullName,
            Email = c.Email,
            Address = c.Address,
            Phone = c.Phone,
            CreatedAt = c.CreatedAt
        };
    }
}
