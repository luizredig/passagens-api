using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class BagagemController : ControllerBase
{
    private APIDbContext? _context;
    public BagagemController(APIDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult<IEnumerable<Bagagem>>> List()
    {
        if (_context is null) return NotFound();

        var bagagens = await _context.Bagagens
            .Include(a => a.Passageiro)
            .ToListAsync();

        return bagagens;
    }
    [HttpGet()]
    [Route("find/{id}")]
    public async Task<ActionResult<Bagagem>> Find([FromRoute] int id)
    {
        if (_context is null) return NotFound();
        var bagagemTemp = await _context.Bagagens.FindAsync(id);
        if (bagagemTemp is null) return NotFound();
        var passageiroTemp = await _context.Passageiros.FindAsync(bagagemTemp.PassageiroId);
        if (passageiroTemp is null) return NotFound();
        bagagemTemp.Passageiro = passageiroTemp;
        return bagagemTemp;
    }
    [HttpPost]
    [Route("post")]
    public async Task<ActionResult<Bagagem>> Post(Bagagem bagagem)
    {
        var existingPassageiro = await _context.Passageiros.FindAsync(bagagem.PassageiroId);

        if (existingPassageiro != null)
        {
            bagagem.Passageiro = existingPassageiro;
        }
        else
        {
            return BadRequest("Passageiro não encontrado.");
        }

        _context.Bagagens.Add(bagagem);
        await _context.SaveChangesAsync();

        return Created("", bagagem);
    }
    [HttpPost]
    [Route("postMany")]
    public async Task<ActionResult> PostBagagens(List<Bagagem> bagagens)
    {
        if (_context is null) return NotFound();

        try
        {
            foreach (var bagagem in bagagens)
            {
                var passageiro = await _context.Passageiros.FindAsync(bagagem.PassageiroId);

                if (passageiro == null)
                {
                    return BadRequest($"Passageiro com ID {bagagem.PassageiroId} não encontrado.");
                }

                _context.Bagagens.Add(bagagem);
            }

            await _context.SaveChangesAsync();
            return Ok("Bagagens adicionadas com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar bagagens: {ex.Message}");
        }
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Bagagem bagagem)
    {
        if (_context is null) return NotFound();
        var passageiro = await _context.Passageiros.FindAsync(bagagem.PassageiroId);
        if (passageiro is null) return NotFound();
        bagagem.Passageiro = passageiro;
        _context.Bagagens.Update(bagagem);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudarpeso/{id}")]
    public async Task<ActionResult> MudarPeso(int id, [FromForm] decimal peso)
    {
        if (_context is null) return NotFound();
        if (_context.Bagagens is null) return NotFound();
        var bagagemTemp = await _context.Bagagens.FindAsync(id);
        if (bagagemTemp is null) return NotFound();
        bagagemTemp.Peso = peso;
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Bagagens is null) return NotFound();
        var bagagemTemp = await _context.Bagagens.FindAsync(id);
        if (bagagemTemp is null) return NotFound();
        _context.Remove(bagagemTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }
}