using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enemix.Models;

[Table("MateriaisEstudo")]
public class MaterialEstudo
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, MaxLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    public AreaConhecimento AreaConhecimento { get; set; }

    // Texto longo extraído do PDF
    public string? ConteudoTeorico { get; set; }

    // Relacionamento 1 para N
    public ICollection<Questao> Questoes { get; set; } = new List<Questao>();

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}