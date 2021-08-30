using System.Threading.Tasks;
using PCBuilder.Domain.Models;

namespace PCBuilder.Domain
{
    public interface IUserService
    {
        Task<UserDto> Login(LoginDto request);
        Task<UserDto> Register(RegistrationDto request);
    }
}