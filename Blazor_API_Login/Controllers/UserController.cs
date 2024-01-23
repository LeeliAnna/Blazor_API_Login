using Blazor_API_Login.Models;
using Blazor_API_Login.Tools;
using BLL.Forms;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor_API_Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // injection de dépendance de la couche BLL
        private readonly UserServices _userServices;
        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }

        
        [HttpGet("index")]
        public IActionResult GetAll()
        {
            return Ok(_userServices.GetAll());
        }

        [HttpGet("details")]
        public IActionResult Details(int id)
        {
            User? u = _userServices.GetById(id);
            if (u is not null)
            {
                return Ok(u);
            }
            return BadRequest();
        }

        [HttpPost("create")]
        public IActionResult Create(RegisterForm form) 
        {
            if (ModelState.IsValid)
            {
                _userServices.Create(form);
                return Ok("Inscription reussie");
            }
            return BadRequest();
        }

        [HttpPatch("unpdatePwd/{id}")]
        public IActionResult UpdatePassword([FromRoute] int id, [FromBody] UpdatePasswordForm form)
        {
            if (ModelState.IsValid)
            {
                form.Id = id;
                _userServices.UpdatePassword(form);
                return Ok("Mot de passe mis à jour");
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(_userServices.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginForm form)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            User connectedUser = _userServices.Login(form.Email, form.Password);

            if (connectedUser is null)
            {
                return BadRequest();
            }

            TokenManager tokenManager = new TokenManager();
            return Ok(tokenManager.GenerateToken(connectedUser));
        }
    }
}
