using PS.Template.Domain.DTO;
using PS.Template.Domain.Query;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PS.Template.AccessData.Query
{
    public class UsuarioQuery : IUsuarioQuery
    {

        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public UsuarioQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseGetAllUsuarios> GetAllUsuarios(int id,string dni)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Usuario")
            .When(!(id == 0), q => q.WhereLike("idUsuario", $"{id}"))
            .When(!string.IsNullOrWhiteSpace(dni), q => q.WhereLike("DNI", $"%{dni}%"));
            var result = query.Get<ResponseGetAllUsuarios>();

            return result.ToList();
        }

    }      
}
