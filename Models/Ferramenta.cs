
using System.ComponentModel.DataAnnotations;

namespace ferramentasAPI.Models;

public class Ferramenta
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da ferramenta é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição da ferramenta é obrigatória.")]
    [MaxLength(250, ErrorMessage = "A descrição deve ter no máximo 250 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    public bool Disponivel { get; set; }

    public int? FuncionarioId { get; set; }

    public Funcionario? Funcionario { get; set; }
}
