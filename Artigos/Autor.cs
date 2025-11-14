using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Autor
{
    public string Nome { get; set; }
    public string Email { get; set; }

    public Autor(string Nome, string Email)
    {
        this.Nome = Nome;
        this.Email = Email;

    }

    public override string ToString()
    {
        return $"-- Autor --\n\nNome: {Nome}\nEmail: {Email}";
    }
}