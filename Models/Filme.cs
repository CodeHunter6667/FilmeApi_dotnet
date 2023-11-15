using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Filme
    {
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
