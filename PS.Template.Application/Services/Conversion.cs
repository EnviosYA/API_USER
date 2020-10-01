using PS.Template.Domain;
using PS.Template.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Application.Services
{
    public class Conversion
    {

        public static Usuario converDTO(UsuarioDto entity)
        {
            var usuario = new Usuario
            {
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Dni = entity.Dni,
                FechaNac = entity.FechaNac,
                IdDireccion = entity.IdDireccion,
                IdCuenta = entity.IdCuenta,
            };

            return usuario;
        }
    }
}
