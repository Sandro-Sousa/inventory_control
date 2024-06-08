using Entities.Entites;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace inventory_control_ZDZCode.WebAPI.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
   
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("v1/GetAllUsers")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                var result = await _userService.GetAllUsers();
                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/GetUserById/{idUser}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(string))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<User>> GetUserById(int idUser)
        {
            try
            {
                var result = await _userService.GetUserById(idUser);
                if (result == null) return this.StatusCode(StatusCodes.Status204NoContent);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/CreateUser")]
        [SwaggerResponse(StatusCodes.Status201Created, "Success", typeof(UserDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<User>> CreateUser(UserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest("Campos Invalidos!!!");

            try
            {
                var result = await _userService.CreateUser(user);
                if (result == null) return this.StatusCode(StatusCodes.Status400BadRequest);

                return this.StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("v1/UpdateUser/{idUser}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(UserDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<bool>> UpdateUser(int idUser, UserDTO user)
        {
            if(idUser != user.IdUser) return this.StatusCode(StatusCodes.Status400BadRequest, "Id do Usuario Invalido!!!");

            if(!ModelState.IsValid) return this.StatusCode(StatusCodes.Status400BadRequest, "Campos Invalidos!!!");

            try
            {
                var result = await _userService.UpdateUser(user);
                if (!result) return this.StatusCode(StatusCodes.Status400BadRequest);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("v1/DeleteUser/{idUser}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Incorrect Header Data", typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server Error", typeof(string))]
        public async Task<ActionResult<bool>> DeleteUser(int idUser)
        {
            try
            {
                var result = await _userService.DeleteUser(idUser);
                if (!result) return this.StatusCode(StatusCodes.Status400BadRequest);

                return this.StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
