namespace Petshop;

public class Gato : Pet
{
    public Gato(string nome, String raca, bool vacinado, int idade, Dono dono)
    {
        Nome = nome;
        Raca = raca;
        Vacinado = vacinado;
        Idade = idade;
        Dono = dono;
        dono.Pets.Add(this);
    }

}