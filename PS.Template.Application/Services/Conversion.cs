using PS.Template.Domain;
using PS.Template.Domain.DTO;
using System.Collections.Generic;

namespace PS.Template.Application.Services
{
    public class Conversion
    {
        public static Usuario ConverUser(RequestPost entity)
        {
            Usuario user = new Usuario()
            {
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Dni = entity.Dni,
                FechaNac = entity.FechaNac,
                IdDireccion = 0,
                IdCuenta = 0
            };

            return user;
        }

        public static CuentaDTO ConverAccount(RequestPost entity)
        {
            CuentaDTO account = new CuentaDTO()
            {
                Contraseña = entity.Cuenta.Password,
                Mail = entity.Cuenta.Email,
                IdTipoCuenta = 1,
                IdUsuario = 0
            };

            return account;
        }


    }
}
