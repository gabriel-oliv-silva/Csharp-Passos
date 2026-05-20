using Enemix.Models;
using Enemix.Models.Dtos;
using Enemix.Repository;

namespace Enemix.Services;

public class MaterialService : IMaterialService
{
    private readonly IMaterialRepository _repository;
    private readonly IPdfParserService _parser;

    public MaterialService(IMaterialRepository repository, IPdfParserService parser)
    {
        _repository = repository;
        _parser = parser;
    }

    public async Task ProcessAndSaveAsync(Stream fileStream, AreaConhecimento area)
    {
        var material = _parser.ParsePdfToMaterial(fileStream, area);
        await _repository.AddAsync(material);
    }
    public async Task<MaterialEstudo?> GetSimuladoCompletoAsync(Guid id)
    {
        return await _repository.GetByIdWithQuestionsAsync(id);
    }
    // Método atualizado repassando os parâmetros para o Repository
    public async Task<PagedResult<MaterialEstudo>> GetMateriaisPaginadosAsync(
        AreaConhecimento area, 
        string? searchTerm, 
        string? sortOrder, 
        int pageNumber, 
        int pageSize)
    {
        return await _repository.GetAllPaginatedAsync(area, searchTerm, sortOrder, pageNumber, pageSize);
    }

    public async Task<PagedResult<Questao>> GetQuestoesPaginadasAsync(int pageNumber, int pageSize)
    {
        return await _repository.GetQuestoesPaginadasAsync(pageNumber, pageSize);
    }
}