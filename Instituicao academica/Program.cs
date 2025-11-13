using Aula_05;

Professor westn = new("West Souza", "Pré-graduado");
Aluno eu = new("Gaburiel", "7", "G93611");
Disciplina disciplina = new("Desenvolvimento de sistemas", 260);

Avaliacao avaliacao = new("Av1", 8, "7", eu, westn, disciplina);

Console.WriteLine(avaliacao);