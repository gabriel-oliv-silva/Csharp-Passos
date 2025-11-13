
public class Livraria
{
    private String Titulo { get; set; }
    private String Autor { get; set; }

    private int nPag;
    public int NumeroDePaginas
    {
        get
        {
            return nPag;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Número de páginas inválido.");
            }

            nPag = value;
        }
    }

    private bool Emprestado { get; set; }

    public Livraria(string title, string autor, int numeroPag)
    {
        Titulo = title;
        Autor = autor;
        NumeroDePaginas = numeroPag;
    }
    
    public void Emprestar()
    {
        Emprestado = true;
        Console.WriteLine($"Livro {Titulo} emprestado com sucesso!");
    }
    public void Devolver()
    {
        Emprestado = false;
        Console.WriteLine($"Livro {Titulo} devolvido com sucesso!");
    }

    public String Status()
    {
        if (Emprestado)
        {
            return $"Livro {Titulo} está emprestado";
        }

        return "Livro disponível!";
    }

    public void SetNumeroDePaginas(int paginas)
    {
        if (paginas <= 0)
            throw new ArgumentException("Número de páginas inválido");

        NumeroDePaginas = paginas;

        if(nPag > 1)
        System.Console.WriteLine($"{Titulo} agora tem {nPag} páginas!");
        else
        System.Console.WriteLine($"{Titulo} agora tem {nPag} página!");
    }

    public override string ToString()
    {
        if (nPag > 1)
            return $"---- Livro ----\n-\tTitulo: {Titulo}\n-\tAutor: {Autor}\n-\tQuantidade de páginas: {NumeroDePaginas} páginas\n";

            return $"---- Livro ----\n-\tTitulo: {Titulo}\n-\tAutor: {Autor}\n-\tQuantidade de páginas: {NumeroDePaginas} página\n";
    }
}