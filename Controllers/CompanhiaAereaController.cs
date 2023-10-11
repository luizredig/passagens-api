using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class CompanhiaAereaController : ControllerBase
{
    private APIDbContext? _context;
    public CompanhiaAereaController(APIDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult<IEnumerable<CompanhiaAerea>>> List()
    {
        if (_context is null) return NotFound();
        return await _context.CompanhiasAereas.ToListAsync();
    }
    [HttpGet()]
    [Route("find/{id}")]
    public async Task<ActionResult<CompanhiaAerea>> Find([FromRoute] int id)
    {
        if (_context is null) return NotFound();
        var companhiaTemp = await _context.CompanhiasAereas.FindAsync(id);
        if (companhiaTemp is null) return NotFound();
        return companhiaTemp;
    }
    [HttpPost]
    [Route("post")]
    public async Task<ActionResult<CompanhiaAerea>> Post(CompanhiaAerea CompanhiaAerea)
    {
        _context.Add(CompanhiaAerea);
        await _context.SaveChangesAsync();
        return Created("", CompanhiaAerea);
    }
    [HttpPost]
    [Route("postMany")]
    public async Task<ActionResult> PostCompanhiasAereas(List<CompanhiaAerea> companhias)
    {
        if (_context is null) return NotFound();
        try
        {
            _context.CompanhiasAereas.AddRange(companhias);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar companhias: {ex.Message}");
        }
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(CompanhiaAerea companhia)
    {
        if (_context is null) return NotFound();
        _context.CompanhiasAereas.Update(companhia);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudarnome/{id}")]
    public async Task<ActionResult> MudarNome(int id, [FromForm] string nome)
    {
        if (_context is null) return NotFound();
        if (_context.CompanhiasAereas is null) return NotFound();
        var companhiaTemp = await _context.CompanhiasAereas.FindAsync(id);
        if (companhiaTemp is null) return NotFound();
        companhiaTemp.Nome = nome;
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.CompanhiasAereas is null) return NotFound();
        var companhiaTemp = await _context.CompanhiasAereas.FindAsync(id);
        if (companhiaTemp is null) return NotFound();
        _context.Remove(companhiaTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }
}