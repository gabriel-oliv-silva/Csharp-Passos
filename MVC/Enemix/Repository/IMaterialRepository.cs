using Enemix.Models;
using Enemix.Models.Dtos;

namespace Enemix.Repository;

public interface IMaterialRepository
{
    Task AddAsync(MaterialEstudo material);
    
    // Atualizado para receber os novos parâmetros de filtro
    Task<PagedResult<MaterialEstudo>> GetAllPaginatedAsync(
        AreaConhecimento area, 
        string? searchTerm, 
        string? sortOrder, 
        int pageNumber, 
        int pageSize);

    Task<PagedResult<Questao>> GetQuestoesPaginadasAsync(int pageNumber, int pageSize);
}