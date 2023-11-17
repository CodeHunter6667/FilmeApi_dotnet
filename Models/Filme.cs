using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmesApi.Models
{
    [Table("tb_filmes")]
    public class Filme
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [Required(ErrorMessage = "O titulo do filme é obrigatorio")]
        [MaxLength(50, ErrorMessage = "O titulo do filme deve ter no maximo 50 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O genero do filme é obrigatorio")]
        [MaxLength(50, ErrorMessage = "O genero deve ter no maximo 50 caracteres")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "A duracao do filme é obrigatorio")]
        [Range(70, 600, ErrorMessage = "A duracao deve ser entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
