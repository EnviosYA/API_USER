using PS.Template.Domain.DTO;
using System.Collections.Generic;

namespace PS.Template.Domain.Query
{
    public interface IUsuarioQuery
    {
        List<ResponseGetAllUsuarios> GetAllUsuarios(int id,string dni);
        Usuario EditarUsuario(int id, RequestPost user);
        int EliminarUsuario(int id);
    }
}
