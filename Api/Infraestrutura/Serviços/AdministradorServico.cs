using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domínio.Interfaces;
using minimal_api.Infraestrutura.Db;
using minimal_api.Domínio.Entidades;
using minimal_api.Domínio.DTOs;

namespace minimal_api.Infraestrutura.Serviços
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;

        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }

        public List<Administrador> Todos(int? pagina = 1, string email = null, string perfil = null)
        {
            var query = _contexto.Administradores.AsQueryable();

            if (!string.IsNullOrEmpty(email))
                query = query.Where(a => a.Email.ToLower() == email.ToLower());

            if (!string.IsNullOrEmpty(perfil))
                query = query.Where(a => a.Perfil.ToLower() == perfil.ToLower());

            int itensPorPagina = 10;

            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }

            return query.ToList();
        }

        public Administrador BuscarPorId(int id)
        {
            return _contexto.Administradores.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Cadastrar(Administrador administrador)
        {
            _contexto.Add(administrador);
            _contexto.SaveChanges();
        }
    }
}