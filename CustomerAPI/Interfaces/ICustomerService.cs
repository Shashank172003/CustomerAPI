using CustomerAPI.DTOs;

namespace CustomerAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponseDto> CreateCustomerAsync(CreateCustomerDto dto);
        Task<IEnumerable<CustomerResponseDto>> GetAllCustomerAsync();
        Task<CustomerResponseDto?> GetCustomerByIdAsync(int id); 
    }
} 
