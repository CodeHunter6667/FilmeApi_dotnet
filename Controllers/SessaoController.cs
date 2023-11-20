using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ActionResult<IEnumerable<ReadSessaoDto>> RecuperaSessoes()
    {
        return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
    }

    [HttpGet("{filmeId:int}/{cinemaId:int}")]
    public ActionResult<ReadEnderecoDto> RecuperaSessaoPorId(int filmeId, int cinemaId)
    {
        var sessao = _context.Sessoes.FirstOrDefault(e => e.FilmeId == filmeId && e.CinemaId == cinemaId);
        if (sessao == null) return NotFound();
        var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
        return Ok(sessaoDto);
    }

    [HttpPost]
    public ActionResult<CreateEnderecoDto> AdicionaEndereco([FromBody] CreateSessaoDto dto)
    {
        if (dto == null) return BadRequest();
        var sessao = _mapper.Map<Sessao>(dto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaSessaoPorId), new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, dto);
    }
}
