
namespace ferramentasAPI.Models;

public class Ferramenta
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public bool Disponivel { get; set; }

    public int? FuncionarioId { get; set; }

    public Funcionario? Funcionario { get; set; }
}
