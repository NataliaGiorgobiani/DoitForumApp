using Forum.Contracts;
using Forum.Models.Identity;

namespace Forum.Service.Implementations
{
    public class AuthService : IAuthService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task Register(RegistrationRequestDto registrationRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
