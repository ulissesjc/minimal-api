using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimal_api.Domínio.Entidades;
using minimal_api.Domínio.Interfaces;
using minimal_api.Infraestrutura.Db;

namespace minimal_api.Infraestrutura.Serviços
{
    public class VeiculoServico : IVeiculoServico
    {

        private readonly DbContexto _contexto;

        public VeiculoServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public List<Veiculo> Todos(int? pagina = 1, string nome = null, string marca = null)
        {

            var query = _contexto.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(v => v.Nome.ToLower() == nome.ToLower());
            }

            if (!string.IsNullOrEmpty(marca))
            {
                query = query.Where(v => v.Marca.ToLower() == marca.ToLower());
            }

            int itensPorPagina = 10;

            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
            }

            return query.ToList();
        }

        public Veiculo BuscarPorId(int id)
        {
            return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
        }

        public void Cadastrar(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public void DeletarPorId(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }

    }
}