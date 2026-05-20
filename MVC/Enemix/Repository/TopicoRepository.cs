
using Enemix.Data;
using Enemix.Repository;
using Enemix.Models.Dtos;
using Enemix.Models;
using Microsoft.EntityFrameworkCore;

namespace Enemix.Repository;

public class TopicoRepository : ITopicoRepository
{
    private readonly AppDbContext _context;

    public TopicoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TopicoEstudo topico)
    {
        await _context.TopicosEstudo.AddAsync(topico);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedResult<TopicoEstudo>> GetPaginatedAsync(
        AreaConhecimento area, 
        string? searchTerm, 
        string? sortOrder, 
        int pageNumber, 
        int pageSize)
    {
        // 1. Cria a query base com filtros obrigatórios
        var query = _context.TopicosEstudo
            .AsNoTracking()
            .Where(t => t.AreaConhecimento == area);

        // 2. Aplica filtro de pesquisa (Search) se fornecido
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            searchTerm = searchTerm.Trim().ToLower();
            query = query.Where(t => t.Titulo.ToLower().Contains(searchTerm));
        }

        // 3. Aplica a ordenação dinâmica (Sort)
        // Por padrão, ordena pela Data de Criação Decrescente (Mais recentes primeiro)
        query = sortOrder?.ToLower() switch
        {
            "asc" => query.OrderBy(t => t.DataCriacao),
            "titulo_asc" => query.OrderBy(t => t.Titulo),
            "titulo_desc" => query.OrderByDescending(t => t.Titulo),
            _ => query.OrderByDescending(t => t.DataCriacao) // "desc" ou nulo
        };

        // 4. Calcula o total de itens APÓS os filtros (para a paginação funcionar corretamente)
        var totalItems = await query.CountAsync();

        // 5. Aplica a paginação (Skip e Take)
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        // 6. Retorna o objeto PagedResult padronizado
        return new PagedResult<TopicoEstudo>(items, totalItems, pageNumber, pageSize);
    }
}