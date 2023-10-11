using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class AeroportoController : ControllerBase
{
    private APIDbContext? _context;
    public AeroportoController(APIDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult<IEnumerable<Aeroporto>>> List()
    {
        if (_context is null) return NotFound();
        return await _context.Aeroportos.ToListAsync();
    }
    [HttpGet()]
    [Route("find/{id}")]
    public async Task<ActionResult<Aeroporto>> Find([FromRoute] int id)
    {
        if (_context is null) return NotFound();
        var aeroportoTemp = await _context.Aeroportos.FindAsync(id);
        if (aeroportoTemp is null) return NotFound();
        return aeroportoTemp;
    }
    [HttpPost]
    [Route("post")]
    public async Task<ActionResult<Aeroporto>> Post(Aeroporto Aeroporto)
    {
        _context.Add(Aeroporto);
        await _context.SaveChangesAsync();
        return Created("", Aeroporto);
    }
    [HttpPost]
    [Route("postMany")]
    public async Task<ActionResult> PostAeroportos(List<Aeroporto> aeroportos)
    {
        if (_context is null) return NotFound();
        try
        {
            _context.Aeroportos.AddRange(aeroportos);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar aeroportos: {ex.Message}");
        }
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Aeroporto aeroporto)
    {
        if (_context is null) return NotFound();
        _context.Aeroportos.Update(aeroporto);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudarnome/{id}")]
    public async Task<ActionResult> MudarNome(int id, [FromForm] string nome)
    {
        if (_context is null) return NotFound();
        if (_context.Aeroportos is null) return NotFound();
        var aeroportoTemp = await _context.Aeroportos.FindAsync(id);
        if (aeroportoTemp is null) return NotFound();
        aeroportoTemp.Nome = nome;
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Aeroportos is null) return NotFound();
        var aeroportoTemp = await _context.Aeroportos.FindAsync(id);
        if (aeroportoTemp is null) return NotFound();
        _context.Remove(aeroportoTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }
}