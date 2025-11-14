using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    public class Artigo
    {
        public string Titulo { get; set; }
        public string Palavra_chave { get; set; }
        public string Instituicao { get; set; }
        public Autor Autor { get; set; }

        public Artigo(string Titulo, string Palavra_chave, string Instituicao, Autor autor)
        {
            this.Titulo = Titulo;
            this.Palavra_chave = Palavra_chave;
            this.Instituicao = Instituicao;
            Autor = autor;
        }

        public override string ToString()
        {
            return $"-- Artigo --\n\nTItulo: {Titulo}\nPalavra-Chave: {Palavra_chave}\nInstituição: {Instituicao}\n{Autor}";
        }
    }