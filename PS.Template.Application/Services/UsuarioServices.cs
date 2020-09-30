using PS.Template.Application.Services.Base;
using PS.Template.Domain;
using PS.Template.Domain.Commands;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.Service;

namespace PS.Template.Application.Services
{


    public class UsuarioServices : BaseService<Usuario>, IUsuarioServices
    {

        private readonly IUsuarioRepository _repository;

        public UsuarioServices(IUsuarioRepository repository) : base(repository)
        {
            _repository = repository;
        }

        //public Usuario AddDTO(UsuarioDto entity)
        //{
        //    var usuario = new Usuario
        //    {
        //        Nombre = entity.Nombre,
        //        Apellido = entity.Apellido,
        //        Dni = entity.Dni,
        //        FechaNac = entity.FechaNac,
        //        IdDireccion = 1,
        //        IdCuenta = 1
        //    };

        //    _repository.Add(usuario);

        //    return usuario;
        //}

    }
}
