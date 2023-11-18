using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FilmesApi.Controllers;
[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult AdicionaFilme([FromBody] CreateFilmeDto dto)
    {
        var filme = _mapper.Map<Filme>(dto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0 ,[FromQuery] int take = 5)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<ReadFilmeDto> RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme =>  filme.Id == id);
        if(filme is null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<UpdateFilmeDto> AtualizaFilme(int id, [FromBody] UpdateFilmeDto dto)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(dto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public ActionResult<UpdateFilmeDto> AtualizaFilmeParcial(int id,
        JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(f=>f.Id == id);
        if (filme is null) return NotFound();
        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme is null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
