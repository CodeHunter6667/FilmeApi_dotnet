using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Models;

[Table("tb_sessoes")]
public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public long FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
    public int? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
}
