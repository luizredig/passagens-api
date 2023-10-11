using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class PassageiroController : ControllerBase
{
    private APIDbContext? _context;
    public PassageiroController(APIDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult<IEnumerable<Passageiro>>> List()
    {
        if (_context is null) return NotFound();
        return await _context.Passageiros.ToListAsync();
    }
    [HttpGet()]
    [Route("find/{id}")]
    public async Task<ActionResult<Passageiro>> Find([FromRoute] int id)
    {
        if (_context is null) return NotFound();
        var passageiroTemp = await _context.Passageiros.FindAsync(id);
        if (passageiroTemp is null) return NotFound();
        return passageiroTemp;
    }
    [HttpPost]
    [Route("post")]
    public async Task<ActionResult<Passageiro>> Post(Passageiro Passageiro)
    {
        _context.Add(Passageiro);
        await _context.SaveChangesAsync();
        return Created("", Passageiro);
    }
    [HttpPost]
    [Route("postMany")]
    public async Task<ActionResult> PostPassageiros(List<Passageiro> passageiros)
    {
        if (_context is null) return NotFound();

        try
        {
            _context.Passageiros.AddRange(passageiros);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar passageiros: {ex.Message}");
        }
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Passageiro passageiro)
    {
        if (_context is null) return NotFound();
        _context.Passageiros.Update(passageiro);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudarnome/{id}")]
    public async Task<ActionResult> MudarNome(int id, [FromForm] string nome)
    {
        if (_context is null) return NotFound();
        if (_context.Passageiros is null) return NotFound();
        var passageiroTemp = await _context.Passageiros.FindAsync(id);
        if (passageiroTemp is null) return NotFound();
        passageiroTemp.Nome = nome;
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Passageiros is null) return NotFound();
        var passageiroTemp = await _context.Passageiros.FindAsync(id);
        if (passageiroTemp is null) return NotFound();
        _context.Remove(passageiroTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }
}