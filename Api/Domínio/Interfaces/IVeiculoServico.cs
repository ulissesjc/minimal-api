using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domínio.Entidades;

namespace minimal_api.Domínio.Interfaces
{
    public interface IVeiculoServico
    {
        List<Veiculo> Todos(int? pagina = 1, string nome = null, string marca = null);

        Veiculo BuscarPorId(int id);

        void Cadastrar(Veiculo veiculo);

        void Atualizar(Veiculo veiculo);

        void DeletarPorId(Veiculo veiculo);
    }
}