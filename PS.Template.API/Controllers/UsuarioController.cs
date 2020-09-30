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
          return _services.Add(Conversion.converDTO(usuario));
        }

        [HttpGet]
        public ActionResult<bool> Get(UsuarioDto usuario)
        {
            return Ok();
        }

    }
}
