using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Models;

[Table("tb_sessoes")]
public class Sessao
{
    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
    public int? CinemaId { get; set; }
    public virtual Cinema Cinema { get; set; }
}
