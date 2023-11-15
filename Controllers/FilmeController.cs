using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FilmesApi.Controllers;
[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public ActionResult AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { filme.Id }, filme);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Filme>> RecuperaFilmes([FromQuery] int skip = 0 ,[FromQuery] int take = 5)
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public ActionResult<Filme?> RecuperaFilmePorId(int id)
    {
        var filme = filmes.FirstOrDefault(filme =>  filme.Id == id);
        if(filme is null) return NotFound();
        return Ok(filme);
    }
}
