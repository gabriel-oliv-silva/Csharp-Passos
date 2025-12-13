using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento_de_Produtos_Eletrônicos
{
    public interface IOperacoesProduto
    {
        void AdicionarProduto(Produto p);
        void RemoverProduto(String codigo);
        Produto BuscarProdutoPorCodigo(String codigo);
        List<Produto> BuscarProdutoPorMarca(Produto p);
        void AtualizarPreco(string codigo, double novoPreco);
        void ListarProdutos();

    }
}