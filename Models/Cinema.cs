using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Models;

[Table("tb_cinemas")]
public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do cinema é obrigatorio")]
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
}
