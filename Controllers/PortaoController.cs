using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class PortaoController : ControllerBase
{
    private APIDbContext? _context;
    public PortaoController(APIDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult<IEnumerable<Portao>>> List()
    {
        if (_context is null) return NotFound();

        var portoes = await _context.Portoes
            .Include(a => a.Aeroporto)
            .ToListAsync();

        return portoes;
    }
    [HttpGet()]
    [Route("find/{id}")]
    public async Task<ActionResult<Portao>> Find([FromRoute] int id)
    {
        if (_context is null) return NotFound();
        var portao = await _context.Portoes.FindAsync(id);
        if (portao is null) return NotFound();
        var aeroporto = await _context.Aeroportos.FindAsync(portao.AeroportoId);
        if (aeroporto is null) return NotFound();
        portao.Aeroporto = aeroporto;
        return portao;
    }
    [HttpPost]
    [Route("post")]
    public async Task<ActionResult<Portao>> Post(Portao portao)
    {
        var existingAeroporto = await _context.Aeroportos.FindAsync(portao.AeroportoId);

        if (existingAeroporto != null)
        {
            portao.Aeroporto = existingAeroporto;
        }
        else
        {
            return BadRequest("Aeroporto não encontrado.");
        }
        _context.Portoes.Add(portao);
        await _context.SaveChangesAsync();

        return Created("", portao);
    }
    [HttpPost]
    [Route("postMany")]
    public async Task<ActionResult> PostPortoes(List<Portao> portoes)
    {
        if (_context is null) return NotFound();

        try
        {
            foreach (var portao in portoes)
            {
                var aeroporto = await _context.Aeroportos.FindAsync(portao.AeroportoId);

                if (aeroporto == null)
                {
                    return BadRequest($"Aeroporto com ID {portao.AeroportoId} não encontrado.");
                }

                _context.Portoes.Add(portao);
            }

            await _context.SaveChangesAsync();
            return Ok("Portões adicionados com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar portões: {ex.Message}");
        }
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Portao portao)
    {
        if (_context is null) return NotFound();
        var aeroporto = await _context.Aeroportos.FindAsync(portao.AeroportoId);
        if (aeroporto is null) return NotFound();
        portao.Aeroporto = aeroporto;
        _context.Portoes.Update(portao);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudarcodigo/{id}")]
    public async Task<ActionResult> MudarCodigo(int id, [FromForm] string codigo)
    {
        if (_context is null) return NotFound();
        if (_context.Portoes is null) return NotFound();
        var portaoTemp = await _context.Portoes.FindAsync(id);
        if (portaoTemp is null) return NotFound();
        portaoTemp.Codigo = codigo;
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Portoes is null) return NotFound();
        var portaoTemp = await _context.Portoes.FindAsync(id);
        if (portaoTemp is null) return NotFound();
        _context.Remove(portaoTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }
}