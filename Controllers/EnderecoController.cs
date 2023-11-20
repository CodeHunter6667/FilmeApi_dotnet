using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadEnderecoDto>> RecuperaEnderecos()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
    }

    [HttpGet("{id:int}")]
    public ActionResult<ReadEnderecoDto> RecuperaEnderecoPorId(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if (endereco == null) return NotFound();
        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    [HttpPost]
    public ActionResult<CreateEnderecoDto> AdicionaEndereco(CreateEnderecoDto dto)
    {
        if (dto == null) return BadRequest();
        var endereco = _mapper.Map<Endereco>(dto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, dto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<UpdateEnderecoDto> AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto dto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if(endereco == null) return NotFound();
        _mapper.Map(dto, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeletaEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e =>e.Id == id);
        if (endereco == null) return NotFound();
        _context.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
}
