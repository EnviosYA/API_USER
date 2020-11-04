using PS.Template.Application.Services.Base;
using PS.Template.Domain;
using PS.Template.Domain.DTO;
using PS.Template.Domain.Interfaces.IGenerateRequest;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.Domain.Interfaces.Service;
using PS.Template.Domain.Query;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PS.Template.Application.Services
{


    public class UsuarioServices : BaseService<Usuario>, IUsuarioServices
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioQuery _query;
        private readonly IGenerateRequest _request;

        public UsuarioServices(IUsuarioRepository repository,IUsuarioQuery query, IGenerateRequest request) : base(repository)
        {
            _repository = repository;
            _query = query;
            _request = request;
        }

        public int DeletearUsuario(int id)
        {
            return _query.EliminarUsuario(id);
        }

        public List<ResponseGetAllUsuarios> GetUsuarios(int id,string dni)
        {
            return _query.GetAllUsuarios(id,dni);
        }

        public Usuario UpDateUsuario(int id, RequestPost user)
        {
            return _query.EditarUsuario(id, user);
        }

        public Usuario CreateUserAccount(RequestPost requestPost)
        {
            string idCuenta = "";
            string idDirecion = "";
            CuentaDTO account = new CuentaDTO()
            {
                Contraseña = requestPost.Password,
                Mail = requestPost.Email,
                IdTipoCuenta = 1,
                IdUsuario = 0
            };
           
            

            IEnumerable<ResultPost> StateCuenta = PostCuentaApi(account);

            foreach (var item in StateCuenta)
            {
                if (item.keyValuePairs.Keys.ToString() == "Cuenta")
                    idCuenta = item.keyValuePairs.Values.ToString();
            }

            IEnumerable<ResultPost> StateDireccion = PostDireccionApi(requestPost.Direccion);
            foreach (var item in StateDireccion)
            {
                if (item.keyValuePairs.Keys.ToString() == "Direccion")
                    idDirecion = item.keyValuePairs.Values.ToString();
            }

            Usuario user = new Usuario()
            {
                Nombre=requestPost.Usuario.Nombre,
                Apellido=requestPost.Usuario.Apellido,
                Dni=requestPost.Usuario.Dni,
                FechaNac=requestPost.Usuario.FechaNac,
                IdDireccion= int.Parse(idDirecion),
                IdCuenta= int.Parse(idCuenta)
            };
            _repository.Add(user);
            return user;
        }

        public IEnumerable<ResultPost> PostCuentaApi(CuentaDTO cuentaDTO)
        {
            string uri = _request.GetUri(2);
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(cuentaDTO);
            IEnumerable<ResultPost> user = _request.ConsultarApiRest<ResultPost>(uri, request);
            return user;
        }

        public IEnumerable<ResultPost> PostDireccionApi(DireccionDTO direccionDTO)
        {
            string uri = _request.GetUri(1);
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(direccionDTO);
            IEnumerable<ResultPost> user = _request.ConsultarApiRest<ResultPost>(uri, request);
            return user;
        }
    }
}
