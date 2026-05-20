namespace Enemix.Repository;

using Enemix.Models.Dtos;
using Enemix.Models;

public interface ITopicoRepository
{
    Task AddAsync(TopicoEstudo topico);
    
    // Busca paginada recebendo Área, Pesquisa (Search), Ordenação (Sort) e Paginação
    Task<PagedResult<TopicoEstudo>> GetPaginatedAsync(
        AreaConhecimento area, 
        string? searchTerm, 
        string? sortOrder, 
        int pageNumber, 
        int pageSize);
}