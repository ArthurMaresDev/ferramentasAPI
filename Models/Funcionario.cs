using System.ComponentModel.DataAnnotations;
namespace ferramentasAPI.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O cargo é obrigatório.")]
        [MaxLength(80, ErrorMessage = "O cargo deve ter no máximo 80 caracteres.")]
        public string Cargo { get; set; } = string.Empty;
        public List<Ferramenta> Ferramentas { get; set; } = new();

    }
}
