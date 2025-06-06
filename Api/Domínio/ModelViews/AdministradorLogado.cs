using minimal_api.Domínio.Enuns;

namespace minimal_api.Domínio.ModelViews
{
    public record AdministradorLogado
    {
        public string Email { get; set; }
        public string Perfil { get; set; }
        public string Token { get; set; }
    }
}