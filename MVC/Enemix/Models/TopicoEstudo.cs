using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enemix.Models;

[Table("TopicosEstudo")]
public class TopicoEstudo
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(150)]
    public string Titulo { get; set; } = string.Empty;

    // Suporta tags HTML para formatação rica
    public string? DescricaoHtml { get; set; }

    [MaxLength(500)]
    public string? ImagemUrl { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    // Mapeamento explícito para garantir os valores 1, 2, 3 e 4
    public AreaConhecimento AreaConhecimento { get; set; }
}