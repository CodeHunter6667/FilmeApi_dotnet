using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FilmesApi.Models;

[Table("tb_enderecos")]
public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo Logradouro é obrigatorio")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "O campo Numero é obrigatorio")]
    public int Numero { get; set; }
    public virtual Cinema Cinema { get; set; }
}
