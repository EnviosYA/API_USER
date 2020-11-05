namespace PS.Template.Domain.DTO
{
    public class RequestPost
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string FechaNac { get; set; }
        public CuentaRequest Cuenta { get; set; }
        public DireccionDTO Direccion { get; set; }
    }
}
