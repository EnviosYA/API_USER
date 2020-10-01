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
        public ActionResult<Usuario> Post(UsuarioDto usuario)
        {

            try
            {
                var user = _services.Add(Conversion.converDTO(usuario));

                return new JsonResult(new ResponseGetGenery { id = user.IdUsuario , Tipo = "Usuario Creado" }) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        public ActionResult<bool> Get([FromQuery] int id,[FromQuery] string dni)
        {
            try
            {
                return new JsonResult(_services.GetUsuarios(id,dni));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult<Usuario> Put(int id, UsuarioDto usuario)
        {
            try
            {
                var user = _services.UpDateUsuario(id, usuario);

                return new JsonResult(new ResponseGetGenery { id = user.IdUsuario, Tipo = "Usuario Modificado" }) { StatusCode = 204 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
