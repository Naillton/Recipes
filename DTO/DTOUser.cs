using System.ComponentModel.DataAnnotations;

namespace Recipes.DTO;

public class UserInsertDto
{
    [Required(ErrorMessage = "Nome obrigatorio")]
    [StringLength(100, ErrorMessage = "Nome deve ter no maximo 100 caracteres")]
    [MinLength(3, ErrorMessage = "Nome deve conter mais de 3 caracteres")]
    public string Nome { get; set; } = string.Empty;


    [Required(ErrorMessage = "Email obrigatorio")]
    [EmailAddress(ErrorMessage = "Email invalido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha obrigatoria")]
    [MinLength(8, ErrorMessage = "A senha deve conter pelo menos 8 caracteres")]
    [MaxLength(20, ErrorMessage = "A senha deve conter ate 20 caracteres")]
    public string Senha { get; set;  } = string.Empty;
}