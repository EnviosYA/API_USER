using PS.Template.Application.Services;
using PS.Template.Domain;
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

        public Usuario EditarUsuario(int id, UsuarioDto user)
        {
            var nomb = user.Nombre;
            var ape = user.Apellido;
            var dni = user.Dni;
            var fec = user.FechaNac;

            var db = new QueryFactory(connection, sqlKataCompiler);
                db.Query("Usuario")
                        .Where("idUsuario", id)
                        .Update(new 
                        {
                            Nombre = nomb,
                            Apellido = ape,
                            Dni = dni,
                            FechaNac = fec,
                        });
            return Conversion.converDTO(user);
        }
    }      
}
