using AutoMapper;
using AutoMapper.Configuration.Annotations;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult<CreateCinemaDto> AdicionaCinema([FromBody] CreateCinemaDto dto)
    {
        var cinema = _mapper.Map<Cinema>(dto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, dto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadCinemaDto>> RecuperaCinemas()
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }

    [HttpGet("{id:int}")]
    public ActionResult<ReadCinemaDto> RecuperaCinemaPorId(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null) return NotFound();
        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<UpdateCinemaDto> AtualizaCinema(int id, [FromBody] UpdateCinemaDto dto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if(cinema == null) return NotFound();
        _mapper.Map(dto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeletaCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null) return NotFound();
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}
