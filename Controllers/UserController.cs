using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaFinaktiva.Auth;
using PruebaFinaktiva.Helpers;
using PruebaFinaktiva.Models;
using PruebaFinaktiva.Models.ViewModels.ResponseVM;
using PruebaFinaktiva.Repositories.Users;
using PruebaFinaktiva.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAPruebaFinaktivaPI.Models.ViewModels.ResponseVM;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaFinaktiva.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private FinaktivaTwoContext context;
        private UserRepositories userRepositories;

        public UserController()
        {
            context = new FinaktivaTwoContext();
            userRepositories = new UserRepositories(context);
        }
        // GET: api/<UserController>
        [HttpGet]
        public ListModelResponseVM<User> Get()
        {
            var ListUser = context.User.ToList();
            try
            {
                Ok(new ListModelResponseVM<User>(200, $"Se encontraron {ListUser.Count} registros", ListUser));
            }
            catch (Exception ex)
            {
                return new ListModelResponseVM<User>(400, ResponseHelper.buildExceptionMessage(ex).ToString(), null);
            }
             return new ListModelResponseVM<User>(200, $"Se encontraron {ListUser.Count} registros", ListUser);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

  
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Route("UpdateUser/{id}")]
        public ActionResult Put(int id,[FromBody] UserVM userVm)
        {
            try
            {
                var valideAdmin = JWTHandler.validateClaims(User.Claims.ToList());
                if (!valideAdmin)
                    return Ok(new BasicResponseVM(400, "No tienes permiso para realizar esta accion"));
                return Ok(userRepositories.updateById(id,userVm));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.buildExceptionMessage(ex));
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Route("DeleteUser/{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var valideAdmin = JWTHandler.validateClaims(User.Claims.ToList());
                if (!valideAdmin)
                    return Ok(new BasicResponseVM(400, "No tienes permiso para realizar esta accion"));
                return Ok(userRepositories.deleteById(id));
            }
            catch (Exception ex)
            {
                return Ok(ResponseHelper.buildExceptionMessage(ex));
            }
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public ActionResult createNewUser([FromBody]UserVM userVm)
        {
            try
            {
                var valideAdmin = JWTHandler.validateClaims(User.Claims.ToList());
                if (userVm == null)
                    return BadRequest(new BasicResponseVM(400, "Los datos de entrada no pueden ser vacíos"));
                if (!valideAdmin)
                    return Ok(new BasicResponseVM(400, "No tienes permiso para realizar esta accion"));
                return Ok(userRepositories.insertNew(userVm));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
