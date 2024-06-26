﻿using Forum.Models.Identity;

namespace Forum.Contracts
{
    public interface IAuthService
    {
        Task Register(RegistrationRequestDto registrationRequestDto);
        Task <LoginResponseDto> Login (LoginRequestDto loginRequestDto);
    }
}
