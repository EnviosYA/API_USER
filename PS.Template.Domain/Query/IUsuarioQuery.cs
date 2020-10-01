using PS.Template.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.Query
{
    public interface IUsuarioQuery
    {
        List<ResponseGetAllUsuarios> GetAllUsuarios(int id,string dni);
        Usuario EditarUsuario(int id, UsuarioDto user);
    }
}
