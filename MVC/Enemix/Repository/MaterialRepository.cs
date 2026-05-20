using Enemix.Data;
using Enemix.Models;
using Enemix.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Enemix.Repository;

using Enemix.Repository;
using Microsoft.EntityFrameworkCore;

public class MaterialRepository : IMaterialRepository
{
    private readonly AppDbContext _context;

    public MaterialRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(MaterialEstudo material)
    {
        await _context.MateriaisEstudo.AddAsync(material);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedResult<MaterialEstudo>> GetAllPaginatedAsync(
        AreaConhecimento area, 
        string? searchTerm, 
        string? sortOrder, 
        int pageNumber, 
        int pageSize)
    {
        // 1. Query base filtrando pela Área e incluindo a contagem de questões (evita Lazy Loading)
        var query = _context.MateriaisEstudo
            .AsNoTracking()
            .Include(m => m.Questoes) // Necessário para mostrar quantas questões tem no card
            .Where(m => m.AreaConhecimento == area);

        // 2. Filtro de Pesquisa pelo Título
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            searchTerm = searchTerm.Trim().ToLower();
            query = query.Where(m => m.Titulo.ToLower().Contains(searchTerm));
        }

        // 3. Ordenação Dinâmica
        query = sortOrder?.ToLower() switch
        {
            "asc" => query.OrderBy(m => m.DataCriacao), // Se você adicionar DataCriacao no MaterialEstudo
            "titulo_asc" => query.OrderBy(m => m.Titulo),
            "titulo_desc" => query.OrderByDescending(m => m.Titulo),
            _ => query.OrderByDescending(m => m.Titulo) // Padrão para simulados: ordem alfabética
        };

        // 4. Paginação
        var totalItems = await query.CountAsync();
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<MaterialEstudo>(items, totalItems, pageNumber, pageSize);
    }

    public async Task<PagedResult<Questao>> GetQuestoesPaginadasAsync(int pageNumber, int pageSize)
    {
        var query = _context.Questoes.AsNoTracking().OrderBy(q => q.Enunciado);
        var totalItems = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedResult<Questao>(items, totalItems, pageNumber, pageSize);
    }
}