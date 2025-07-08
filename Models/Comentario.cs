namespace Recipes.Models;
using System.ComponentModel.DataAnnotations;

public class Comentario
{
    [StringLength(300, ErrorMessage = "O comentario deve ter no maximo 300 caracteres")]
    public string texto { get; set; } = string.Empty;
}