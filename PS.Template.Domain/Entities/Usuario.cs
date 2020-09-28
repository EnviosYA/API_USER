using System;
using System.Collections.Generic;

namespace PS.Template.AccessData.cualquiera
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string FechaNac { get; set; }
        public int IdDireccion { get; set; }
        public int IdCuenta { get; set; }
    }
}
