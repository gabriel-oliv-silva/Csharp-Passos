using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel_Oliveira_Silva___Avaliação
{
    public class PetShop : IOperacoesAnimal
    {
        public List<Animal> Animais;

        public void AdicionarAnimal(Animal a)
        {
            Animais ??= [];
            Animais.Add(a);
        }

        public void AtualizarPrecoBanho(string nome, double novoPreco)
        {
            if (Animais.Count == 0) // Se a contagem de itens dentro da lista for 0 (não tiver nada), dispara exceção de lista vazia.
                throw new Exception("A lista está vazia!");

            var animal = Animais.Find(a => a.Nome == nome);
            if (animal != null)
            {
                Console.Clear();
                System.Console.WriteLine($"Atualizando preço de {animal.Nome}...");
                Thread.Sleep(1000);
                animal.PrecoBanho = novoPreco;
                System.Console.WriteLine("Preço atualizado com sucesso!");
                Thread.Sleep(800);
            }
            else
                throw new Exception("Animal não encontrado!");

        }

        public Animal BuscarPorNome(string nome)
        {
            if (Animais.Count == 0)
                throw new Exception("A lista está vazia!");

            var animal = Animais.Find(a => a.Nome == nome);
            if (animal != null)
                return animal;
            else
                throw new Exception("Animal não encontrado!");
        }

        public void ListarAnimais()
        {
            if (Animais.Count == 0)
                throw new Exception("A lista está vazia!");

            foreach (var item in Animais)
            {
                item.ExibirDetalhes();
            }
        }

        public void RemoverAnimal(string nome)
        {
            if (Animais.Count == 0)
                throw new Exception("A lista está vazia!");

            var animal = Animais.Find(a => a.Nome == nome);
            if (animal != null)
                Animais.Remove(animal);
            else
                throw new Exception("Animal não encontrado!");

        }
        public void LimparLista()
        {
            if (Animais.Count == 0)
                throw new Exception("A lista está vazia");
            else
            {
                Animais.Clear(); // Limpa todos os elementos da lista.
                System.Console.WriteLine("Lista limpa com sucesso!");
            }

        }
    }
}