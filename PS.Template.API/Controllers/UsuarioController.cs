using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
                return new JsonResult(_services.Add(Conversion.converDTO(usuario))) { StatusCode = 201 };
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

    }
}
