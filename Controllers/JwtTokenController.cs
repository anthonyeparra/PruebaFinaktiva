using Microsoft.AspNetCore.Mvc;
using PruebaFinaktiva.Auth;
using PruebaFinaktiva.Helpers;
using PruebaFinaktiva.Models;
using PruebaFinaktiva.Repositories.Users;
using PruebaFinaktiva.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAPruebaFinaktivaPI.Models.ViewModels.ResponseVM;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaFinaktiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenController : ControllerBase
    {
        private JWTHandler JWT;
        private FinaktivaTwoContext context;
        private UserRepositories userRepositories;

        public JwtTokenController()
        {
            JWT = new JWTHandler();
            context = new FinaktivaTwoContext();
            userRepositories = new UserRepositories(context);
        }
        [HttpPost]
        [Route("Auth")]
        public ActionResult Auth([FromBody] UserTokenVM loginData)
        {

            try
            {
                bool validUser = false;
                //VALIDAMOS CUERPO DE SOLICITUD
                if (!ModelState.IsValid)
                {
                    return BadRequest(new BasicResponseVM(400, ResponseHelper.buildModelStateErrorResponse(ModelState)));
                }
                // Validamos que el usuario ingresado sea igual al de la base de datos 
                validUser = userRepositories.validateUser(loginData);
                // VALIDAMOS CREDENCIALES DE USUARIO
                if (validUser)
                {
                    return Ok(JWT.generateTokenJwt(loginData));
                }
                else
                {
                    return Ok(new BasicResponseVM(200, "Credenciales incorrectas."));
                }

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
    }
}
