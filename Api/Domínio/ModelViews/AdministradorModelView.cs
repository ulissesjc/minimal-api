using minimal_api.Domínio.Enuns;

namespace minimal_api.Domínio.ModelViews
{
    public record AdministradorModelView
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }
    }
}