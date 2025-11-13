Console.Clear();

Livraria livro = new("Wikipedia", "Internet", 999);

Console.WriteLine(livro.Status());

livro.Emprestar();

Console.WriteLine(livro.Status());

livro.Devolver();

livro.SetNumeroDePaginas(1);

Console.WriteLine(livro);