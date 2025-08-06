using System.ComponentModel.DataAnnotations;

namespace Recipes.DTO;

public class RecipeInsertDto
{
    [Required(ErrorMessage = "Titulo obrigatorio")]
    [StringLength(100, ErrorMessage = "Titulo deve ter no maximo 100 caracteres")]
    [MinLength(10, ErrorMessage = "Titulo deve conter mais de 3 caracteres")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Descricao obrigatoria")]
    [MinLength(100, ErrorMessage = "A descricao deve conter pelo menos 8 caracteres")]
    [MaxLength(200, ErrorMessage = "A descricao deve conter ate 20 caracteres")]
    public string Descricao { get; set;  } = string.Empty;
}