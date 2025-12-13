using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Gerenciamento_de_Produtos_Eletrônicos
{
    public class Loja : IOperacoesProduto
    {
        List<Produto> Produtos { get; set; }

        public Loja()
        {
        }

        public void AdicionarProduto(Produto p)
        {
            Produtos ??= [];
            foreach (var item in Produtos)
            {
                if (string.Equals(item.Codigo, p.Codigo))
                    throw new InvalidDataException("Já existe um celular com este código");
            }

            Produtos.Add(p);
        }

        public void RemoverProduto(string codigo)
        {
            var item = Produtos.Find(produto => produto.Codigo == codigo);
            if (item == null)
                Console.WriteLine("Nenhum produto encontrado!");
            else
            {
                Produtos.Remove(item);
                Console.WriteLine($"{item.Nome} removido com sucesso!");
            }
        }

        public Produto BuscarProdutoPorCodigo(string codigo)
        {
            foreach (var item in Produtos)
            {
                if (string.Equals(item.Codigo, codigo))
                    return item;
            }

            return null;
        }

        public List<Produto> BuscarProdutoPorMarca(Produto p)
        {
            List<Produto> produtos = new List<Produto>();
            foreach (var item in Produtos)
            {
                if (Equals(item, p))
                    produtos.Add(item);
            }

            if (produtos.Count > 0)
                return produtos;

            return null;
        }

        public void AtualizarPreco(string codigo, double novoPreco)
        {
            foreach (var item in Produtos)
            {
                if (string.Equals(item.Codigo, codigo))
                {
                    Console.WriteLine(
                        $"\nPreço do item {item.Nome} alterado de R${item.Preco} para R${novoPreco} com sucesso!");
                    item.Preco = novoPreco;
                }
            }
        }

        public void ListarProdutos()
        {
            foreach (var item in Produtos)
            {
                Console.WriteLine(item);
            }

            if (Produtos.Count == 0)
                throw new Exception("A lista está vazia!");
        }
    }
}