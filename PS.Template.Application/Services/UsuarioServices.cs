using PS.Template.Application.Services.Base;
using PS.Template.Domain;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.Service;
using PS.Template.Domain.Query;
using System.Collections.Generic;

namespace PS.Template.Application.Services
{


    public class UsuarioServices : BaseService<Usuario>, IUsuarioServices
    {

        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioQuery _query;

        public UsuarioServices(IUsuarioRepository repository,IUsuarioQuery query) : base(repository)
        {
            _repository = repository;
            _query = query;
        }

        public int DeletearUsuario(int id)
        {
            return _query.EliminarUsuario(id);
        }

        public List<ResponseGetAllUsuarios> GetUsuarios(int id,string dni)
        {
            return _query.GetAllUsuarios(id,dni);
        }

        public Usuario UpDateUsuario(int id, UsuarioDto user)
        {
            return _query.EditarUsuario(id, user);
        }
    }
}
