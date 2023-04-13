﻿using Api_Restaurant_Order.Application.DTOs.Authorization;
using Api_Restaurant_Order.Application.Services.Interface.Authorization;
using Api_Restaurant_Order.Domain.Entities.Authorization;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace Api_Restaurant_Order.Application.Services.Authorization
{
    public class GenerateToken : IGenerateToken
    {
        private readonly IConfiguration _configure;

        public GenerateToken(IConfiguration configure)
        {
            _configure = configure;
        }

        public TokenDTO GenerateAccessToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.SerialNumber, user.Id.ToString())
            };

            user.UserPermissions.ToList().ForEach(p =>
            {
                claims.Add(new Claim(ClaimTypes.Role, p.Permission.PermissionName));

            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configure.GetSection("JwtConfig:Key").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var expires = DateTime.Now.AddHours(1);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: cred);

            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = expires.AddMinutes(30),
                Created = DateTime.Now
            };
        }
    }
}
