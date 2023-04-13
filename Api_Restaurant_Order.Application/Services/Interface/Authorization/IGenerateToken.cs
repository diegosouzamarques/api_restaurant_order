using Api_Restaurant_Order.Application.DTOs.Authorization;
using Api_Restaurant_Order.Domain.Entities.Authorization;

namespace Api_Restaurant_Order.Application.Services.Interface.Authorization
{
    public interface IGenerateToken
    {
        public TokenDTO GenerateAccessToken(User user);
    }
}
