using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using minimal_api.Domínio.DTOs;
using minimal_api.Domínio.Entidades;
using minimal_api.Domínio.Interfaces;
using Test.Domain.Entidades;

namespace Test.Mocks
{
    public class AdministradorServicoMock : IAdministradorServico
    {
        private static List<Administrador> administradores = new List<Administrador>()
        {
            new Administrador{
                Id = 1,
                Email = "adm@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            },
            new Administrador{
                Id = 2,
                Email = "editor@teste.com",
                Senha = "123456",
                Perfil = "Editor"
            },
        };
        public Administrador? BuscarPorId(int id)
        {
            return administradores.Find(a => a.Id == id);
        }

        public void Cadastrar(Administrador administrador)
        {
            administrador.Id = administradores.Count() + 1;
            administradores.Add(administrador);
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            return administradores.Find(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
        }

        public List<Administrador> Todos(int? pagina, string email, string perfil)
        {
            return administradores;
        }
    }
}