using Enemix.Services;
using Enemix.Repository;
using Enemix.Models;
using Microsoft.AspNetCore.Mvc;

namespace Enemix.Controllers;

public class MateriaisController : Controller
{
    private readonly IMaterialService _materialService;
    private readonly ITopicoRepository _topicoService;

    public MateriaisController(IMaterialService materialService, ITopicoRepository topicoService)
    {
        _materialService = materialService;
        _topicoService = topicoService;
    }

    public IActionResult Index() => View();

    public IActionResult EscolhaModo(AreaConhecimento area)
    {
        ViewBag.Area = area;
        return View(area);
    }

    public async Task<IActionResult> ModoEstudo(AreaConhecimento area, string? search, string? sort, int page = 1)
    {
        var resultado = await _topicoService.GetPaginatedAsync(area, search, sort, page, 50);
        ViewBag.Area = area;
        return View(resultado);
    }

    public async Task<IActionResult> ModoSimulado(AreaConhecimento area, string? search, string? sort, int page = 1)
    {
        var resultado = await _materialService.GetMateriaisPaginadosAsync(area, search, sort, page, 15);
        ViewBag.Area = area;
        return View(resultado);
    }

    public IActionResult Admin()
    {
        // Passa as mensagens de sucesso/erro para a View
        ViewBag.Sucesso = TempData["Sucesso"];
        ViewBag.Erro = TempData["Erro"];
        return View();
    }

    // ROTA CORRIGIDA: Apenas [HttpGet] padrão
    [HttpGet]
    public IActionResult DownloadTemplate()
    {
        var templateText = @"
[TITULO] Exemplo de Template ENEMIX - Área de Humanas
[TEORIA]
A Revolução Industrial foi um conjunto de mudanças que aconteceram na Europa nos séculos XVIII e XIX. 
A principal característica foi a transição da produção manual para a mecanizada.
[FIM_TEORIA]
[QUESTAO]
[ENUNCIADO]
(ENEM 202X) Qual foi a principal consequência da Revolução Industrial para a organização do trabalho?
[A] A eliminação total do trabalho urbano.
[B] A consolidação do trabalho assalariado nas fábricas.
[C] O retorno ao sistema de produção feudal.
[D] A diminuição da produção em larga escala.
[E] A extinção do uso de máquinas.
[RESPOSTA] B
[RESOLUCAO]
A alternativa B é a correta.
[FIM_QUESTAO]
".Trim();

        var bytes = System.Text.Encoding.UTF8.GetBytes(templateText);
        return File(bytes, "text/plain", "Template_Enemix.txt");
    }

    // ROTA CORRIGIDA: Apenas [HttpPost] padrão
    [HttpPost]
    public async Task<IActionResult> UploadPdf(IFormFile file, AreaConhecimento area)
    {
        try
        {
            if (file != null && file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                await _materialService.ProcessAndSaveAsync(stream, area);
                TempData["Sucesso"] = "PDF processado e simulado salvo com sucesso!";
            }
            else
            {
                TempData["Erro"] = "Por favor, selecione um arquivo PDF válido.";
            }
        }
        catch (Exception ex)
        {
            TempData["Erro"] = $"Erro ao processar: {ex.Message}";
        }
        
        return RedirectToAction("Admin");
    }

    // ROTA CORRIGIDA: Apenas [HttpPost] padrão + Tratamento de erro do ModelState
    [HttpPost]
    public async Task<IActionResult> CadastrarTopico(TopicoEstudo topico)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _topicoService.AddAsync(topico);
                TempData["Sucesso"] = "Pílula de estudo cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["Erro"] = $"Erro ao salvar no banco: {ex.Message}";
            }
        }
        else
        {
            // Se caiu aqui, é porque o Enum veio com valor 0 ou faltou título
            TempData["Erro"] = "Preencha todos os campos obrigatórios corretamente (Título e Área).";
        }
        
        return RedirectToAction("Admin");
    }
}