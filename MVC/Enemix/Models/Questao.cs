using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enemix.Models;

[Table("Questoes")]
public class Questao
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey("MaterialEstudo")]
    public Guid MaterialEstudoId { get; set; }
    public MaterialEstudo MaterialEstudo { get; set; } = null!;

    [Required]
    public string Enunciado { get; set; } = string.Empty;

    public string? AlternativaA { get; set; }
    public string? AlternativaB { get; set; }
    public string? AlternativaC { get; set; }
    public string? AlternativaD { get; set; }
    public string? AlternativaE { get; set; }

    [MaxLength(1)]
    public string AlternativaCorreta { get; set; } = string.Empty;

    public string? Resolucao { get; set; }
}