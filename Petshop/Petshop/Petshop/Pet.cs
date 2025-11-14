namespace Petshop;

public abstract class Pet
{
    public String Nome { get; set; }
    public String Raca { get; set; }
    public bool Vacinado { get; set; }
    public int Idade { get; set; }
    public Dono Dono { get; set; }

    public override string ToString()
    {
        if (Vacinado)
            return
                $"\n\t--- Pet ---\n\nNome: {Nome}\nRaca: {Raca}\nIdade: {Idade}\nEstá vacinado? Sim\nDados acerca do dono: {Dono}\n";

        return
            $"\n\t--- Pet ---\n\nNome: {Nome}\nRaca: {Raca}\nIdade: {Idade}\nEstá vacinado? Não\nDados acerca do dono: {Dono}\n";
    }
}