using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PruebaFinaktiva.Helpers;
using PruebaFinaktiva.Models;
using PruebaFinaktiva.Models.ViewModels.ResponseVM;
using PruebaFinaktiva.Repositories.Users;
using PruebaFinaktiva.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinaktiva.Auth
{
    public class JWTHandler
    {
        private FinaktivaTwoContext context;
        private UserRepositories userRepositories;
        private IConfiguration config;
        public JWTHandler()
        {
            context = new FinaktivaTwoContext();
            userRepositories = new UserRepositories(context);
            config = ConfigHelper.readAppConfig();
        }
        //FUNCIÓN PARA GENERAR TOKEN DE SESIÓN DE USUARIO
        public UniqueModelResponse<string> generateTokenJwt(UserTokenVM modelTokenUser)
        {
            // Consultar si tiene rol de admin 
            string validTrue = userRepositories.validateRole(modelTokenUser); ;
            // Creamos los claims (pertenencias, características) del usuario
            var claims = new[]
            {
            new Claim("Admin", validTrue),
            };
            //OBTENEMOS CREDENCIALES
            string key = config.GetValue<string>("JWT:Key");
            string issuer = config.GetValue<string>("JWT:Issuer");

            //PROCESAMOS LA CLAVE DE SEGURIDAD
            var encodeKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(encodeKey, SecurityAlgorithms.HmacSha256);

            //GENERAMOS TOKEN
            var newToken = new JwtSecurityToken(issuer, issuer, claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: credentials);

            return new UniqueModelResponse<string>(200, "Token generado correctamente.", new JwtSecurityTokenHandler().WriteToken(newToken));
        }
        public static bool validateClaims(List <Claim> claims)
        {
            return claims.Any(x => x.Type == "Admin" && x.Value == "1");
        }
    }
}
