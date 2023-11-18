using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo Logradouro é obrigatorio")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "O campo Numero é obrigatorio")]
    public int Numero { get; set; }
}
