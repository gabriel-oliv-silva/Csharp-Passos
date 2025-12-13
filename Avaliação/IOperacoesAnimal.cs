using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel_Oliveira_Silva___Avaliação
{
    public interface IOperacoesAnimal
    {
        public void AdicionarAnimal(Animal a);
        public void RemoverAnimal(string nome);
        public Animal BuscarPorNome(string nome);
        public void AtualizarPrecoBanho(string nome, double novoPreco);
        public void ListarAnimais();
        public void LimparLista(); // Novo método para limpar todos os itens da lista.

    }
}