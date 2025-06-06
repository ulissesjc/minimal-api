using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domínio.DTOs;
using minimal_api.Domínio.Entidades;

namespace minimal_api.Domínio.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador Login(LoginDTO loginDTO);

        List<Administrador> Todos(int? pagina, string email, string perfil);

        Administrador BuscarPorId(int id);

        void Cadastrar(Administrador administrador);
    }
}