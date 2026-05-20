using System.Text.RegularExpressions;
using Enemix.Models;
using Enemix.Services;
using UglyToad.PdfPig;

public class PdfParserService : IPdfParserService
{
    public MaterialEstudo ParsePdfToMaterial(Stream fileStream, AreaConhecimento area)
    {
        // 1. Extrai todo o texto do PDF usando PdfPig
        using var document = PdfDocument.Open(fileStream);
        var fullText = string.Join(Environment.NewLine, document.GetPages().Select(p => p.Text));

        if (string.IsNullOrWhiteSpace(fullText))
            throw new InvalidOperationException("O PDF está vazio ou não contém texto extraível.");

        var material = new MaterialEstudo { AreaConhecimento = area };

        // 2. Extrair Título
        var tituloMatch = Regex.Match(fullText, @"\[TITULO\](.*?)\n", RegexOptions.Singleline);
        material.Titulo = tituloMatch.Success ? tituloMatch.Groups[1].Value.Trim() : "Material Sem Título";

        // 3. Extrair Teoria
        var teoriaMatch = Regex.Match(fullText, @"\[TEORIA\](.*?)\[FIM_TEORIA\]", RegexOptions.Singleline);
        material.ConteudoTeorico = teoriaMatch.Success ? teoriaMatch.Groups[1].Value.Trim() : null;

        // 4. Extrair Questões (Loop pois pode haver N questões)
        var questaoMatches = Regex.Matches(fullText, @"\[QUESTAO\](.*?)\[FIM_QUESTAO\]", RegexOptions.Singleline);
        
        foreach (Match match in questaoMatches)
        {
            var block = match.Groups[1].Value;
            var questao = new Questao();

            // Enunciado
            var enunMatch = Regex.Match(block, @"\[ENUNCIADO\](.*?)\[A\]", RegexOptions.Singleline);
            questao.Enunciado = enunMatch.Success ? enunMatch.Groups[1].Value.Trim() : string.Empty;

            // Alternativas (Usando a próxima tag como delimitador)
            questao.AlternativaA = GetAlternative(block, @"\[A\](.*?)\[B\]");
            questao.AlternativaB = GetAlternative(block, @"\[B\](.*?)\[C\]");
            questao.AlternativaC = GetAlternative(block, @"\[C\](.*?)\[D\]");
            questao.AlternativaD = GetAlternative(block, @"\[D\](.*?)\[E\]");
            questao.AlternativaE = GetAlternative(block, @"\[E\](.*?)\[RESPOSTA\]");

            // Resposta Correta
            var respMatch = Regex.Match(block, @"\[RESPOSTA\]([A-E])");
            questao.AlternativaCorreta = respMatch.Success ? respMatch.Groups[1].Value : string.Empty;

            // Resolução
            var resMatch = Regex.Match(block, @"\[RESOLUCAO\](.*?)$", RegexOptions.Singleline);
            questao.Resolucao = resMatch.Success ? resMatch.Groups[1].Value.Trim() : null;

            material.Questoes.Add(questao);
        }

        if (!material.Questoes.Any())
            throw InvalidOperationException("Nenhuma questão foi encontrada no PDF. Verifique o formato das tags.");

        return material;
    }

    // Método auxiliar para evitar repetição de código na extração de alternativas
    private string? GetAlternative(string block, string pattern)
    {
        var match = Regex.Match(block, pattern, RegexOptions.Singleline);
        return match.Success ? match.Groups[1].Value.Trim() : null;
    }

    private static InvalidOperationException InvalidOperationException(string message) => new(message);
}