using Enemix.Models;
using Enemix.Models.Dtos;

namespace Enemix.Services;

public interface IMaterialService
{
    Task ProcessAndSaveAsync(Stream fileStream, AreaConhecimento area);
    
    // Assinatura atualizada
    Task<PagedResult<MaterialEstudo>> GetMateriaisPaginadosAsync(
        AreaConhecimento area, 
        string? searchTerm, 
        string? sortOrder, 
        int pageNumber, 
        int pageSize);
        
    Task<PagedResult<Questao>> GetQuestoesPaginadasAsync(int pageNumber, int pageSize);
}