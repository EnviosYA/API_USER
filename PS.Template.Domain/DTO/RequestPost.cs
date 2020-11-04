namespace PS.Template.Domain.DTO
{
    public class RequestPost
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UsuarioDTO Usuario { get;set; }
        public DireccionDTO Direccion { get; set; }
    }
}
