using PS.Template.Domain.DTO;
using PS.Template.Domain.Service.Base;
using System.Collections.Generic;

namespace PS.Template.Domain.Interfaces.Service
{
    public interface IUsuarioServices : IBaseService<Usuario>
    {
        List<ResponseGetAllUsuarios> GetUsuarios(int id,string dni);
        Usuario UpDateUsuario(int id, RequestPost user);
        Usuario CreateUserAccount(RequestPost requestPost);
        int DeletearUsuario(int id);
    }
}
