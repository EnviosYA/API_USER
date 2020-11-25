using System;
using Microsoft.AspNetCore.Mvc;
using PS.Template.Application.Services;
using PS.Template.Domain;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Service;

namespace PS.Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioServices _services;
        public UsuarioController(IUsuarioServices services)
        {
            _services = services;
        }

        [HttpPost]
        public ActionResult<Usuario> Post(RequestPost usuario)
        {
            try
            {
                var user = _services.CreateUserAccount(usuario);
                if (user != null)
                {
                    return new JsonResult(new ResponseGetGenery { id = user.IdUsuario, Tipo = "Usuario Creado", Status = true }) { StatusCode = 201 };
                }
                else
                {
                    return new JsonResult(new ResponseGetGenery { id = 0 , Tipo = null}) { StatusCode = 400};
                }
            }
            catch 
            {
                return new JsonResult(new ResponseGetGenery { id = 0, Tipo = null }) { StatusCode = 500 };
            }
        }

        [HttpGet]
        public ActionResult<bool> Get([FromQuery] int id, [FromQuery] string dni)
        {
            try
            {
                return new JsonResult(_services.GetUsuarios(id, dni));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult<Usuario> Put(int id, RequestPost usuario)
        {
            try
            {
                var user = _services.UpDateUsuario(id, usuario);

                return new JsonResult(new ResponseGetGenery { id = user.IdUsuario, Tipo = "Usuario Modificado", Status = true }) { StatusCode = 204 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete] 
        public ActionResult<Usuario> Delete(int id)
        {
            try
            {
                var idAfec = _services.DeletearUsuario(id);

                return new JsonResult(new ResponseGetGenery { id = idAfec, Tipo = "Usuario Borrado", Status = true }) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
