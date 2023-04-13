using Api_Restaurant_Order.Application.DTOs.Authorization;

namespace Api_Restaurant_Order.Application.Services.Interface.Authorization
{
    public interface IUserService
    {
        Task<ResultService<UserDTO>> Register(UserDTO userDTO);
        Task<ResultService<TokenDTO>> Signin(UserSigninDTO userSigninDTO);
        Task<ResultService<TokenDTO>> RefreshToken(RefreshTokenDTO refreshTokenDTO);
        Task<ResultService<ICollection<PermissionDTO>>> PermissionAsync();
    }
}
