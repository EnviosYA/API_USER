using PS.Template.Domain;
using PS.Template.Domain.DTO;
using System.Collections.Generic;

namespace PS.Template.Application.Services
{
    public class Conversion
    {
        public static Usuario converDTO(RequestPost entity)
        {
            //IEnumerable<Autenticacion> result = GetDataApi(2);
            var usuario = new Usuario
            {
                Nombre = entity.Usuario.Nombre,
                Apellido = entity.Usuario.Apellido,
                Dni = entity.Usuario.Dni,
                FechaNac = entity.Usuario.FechaNac,
                //IdDireccion = entity.Direccion.
                //IdCuenta = entity.IdCuenta,
            };
            return usuario;
        }
    }
}
