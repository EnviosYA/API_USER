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
using System.Linq;

namespace PS.Template.Application.Services
{


    public class UsuarioServices : BaseService<Usuario>, IUsuarioServices
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioQuery _query;
        private readonly IGenerateRequest _request;

        public UsuarioServices(IUsuarioRepository repository, IUsuarioQuery query, IGenerateRequest request) : base(repository)
        {
            _repository = repository;
            _query = query;
            _request = request;
        }

        public int DeletearUsuario(int id)
        {
            return _query.EliminarUsuario(id);
        }

        public List<ResponseGetAllUsuarios> GetUsuarios(int id, string dni)
        {
            return _query.GetAllUsuarios(id, dni);
        }

        public Usuario UpDateUsuario(int id, RequestPost user)
        {
            return _query.EditarUsuario(id, user);
        }

        public Usuario CreateUserAccount(RequestPost requestPost)
        {
            Usuario user = null;

            ResultPost StateDireccion = PostDireccionApi(requestPost.Direccion).First();

            if (StateDireccion.Id != null || StateDireccion.Id != "null")
            {
                user = Conversion.ConverUser(requestPost);

                user.IdDireccion = int.Parse(StateDireccion.Id);

                _repository.Add(user);

                if (user != null)
                {
                    CuentaDTO account = Conversion.ConverAccount(requestPost, user.IdUsuario);

                    ResultPost StateCuenta = PostCuentaApi(account).First();

                    if (StateCuenta.Id != null || StateCuenta.Id != "null")
                    {
                        user.IdCuenta = int.Parse(StateCuenta.Id);
                        _repository.Edit(user);
                    }
                    else
                    {
                        _repository.Delete(user);
                        user = null;
                    }
                }
            }

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

        public List<ResultPost> PostDireccionApi(DireccionDTO direccionDTO)
        {
            string uri = _request.GetUri(1);
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(direccionDTO);
            List<ResultPost> user = _request.ConsultarApiRest<ResultPost>(uri, request);
            return user;
        }
    }
}
