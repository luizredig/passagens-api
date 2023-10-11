using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class VooController : ControllerBase
{
    private APIDbContext? _context;
    public VooController(APIDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult<IEnumerable<Voo>>> List()
    {
        if (_context is null) return NotFound();

        var voos = await _context.Voos
            .Include(a => a.Aviao)
            .Include(a => a.Aviao.CompanhiaAerea)
            .Include(a => a.OrigemAeroporto)
            .Include(a => a.DestinoAeroporto)
            .ToListAsync();

        return voos;
    }
    [HttpGet()]
    [Route("find/{id}")]
    public async Task<ActionResult<Voo>> Find([FromRoute] int id)
    {
        if (_context is null) return NotFound();
        var vooTemp = await _context.Voos.FindAsync(id);
        if (vooTemp is null) return NotFound();
        var aviaoTemp = await _context.Avioes.FindAsync(vooTemp.AviaoId);
        if (aviaoTemp is null) return NotFound();
        var companhiaTemp = await _context.CompanhiasAereas.FindAsync(vooTemp.AviaoId);
        if (companhiaTemp is null) return NotFound();
        var aeroportoOrigemTemp = await _context.Aeroportos.FindAsync(vooTemp.OrigemAeroportoId);
        if (aeroportoOrigemTemp is null) return NotFound();
        var aeroportoDestinoTemp = await _context.Aeroportos.FindAsync(vooTemp.DestinoAeroportoId);
        if (aeroportoDestinoTemp is null) return NotFound();

        vooTemp.Aviao = aviaoTemp;
        vooTemp.Aviao.CompanhiaAerea = companhiaTemp;
        vooTemp.OrigemAeroporto = aeroportoOrigemTemp;
        vooTemp.DestinoAeroporto = aeroportoDestinoTemp;

        return vooTemp;
    }
    [HttpPost]
    [Route("post")]
    public async Task<ActionResult<Voo>> Post(Voo voo)
    {
        // Verificar se o Avião existe pelo ID
        var existingAviao = await _context.Avioes.FindAsync(voo.AviaoId);
        if (existingAviao == null)
        {
            return BadRequest("Avião não encontrado.");
        }

        // Verificar se a Companhia Aérea existe pelo ID
        var existingCompanhiaAerea = await _context.CompanhiasAereas.FindAsync(existingAviao.CompanhiaAereaId);
        if (existingCompanhiaAerea == null)
        {
            return BadRequest("Companhia Aérea não encontrada.");
        }

        // Verificar se os Aeroportos de origem e destino existem pelo ID
        var existingOrigemAeroporto = await _context.Aeroportos.FindAsync(voo.OrigemAeroportoId);
        var existingDestinoAeroporto = await _context.Aeroportos.FindAsync(voo.DestinoAeroportoId);
        if (existingOrigemAeroporto == null || existingDestinoAeroporto == null)
        {
            return BadRequest("Aeroporto de origem ou destino não encontrado.");
        }

        if (existingOrigemAeroporto.Id == existingDestinoAeroporto.Id)
        {
            return BadRequest("O aeroporto de origem não pode ser o mesmo de destino.");
        }

        // Agora podemos criar o Voo e relacioná-lo aos objetos existentes
        voo.Aviao = existingAviao;
        voo.Aviao.CompanhiaAerea = existingCompanhiaAerea;
        voo.OrigemAeroporto = existingOrigemAeroporto;
        voo.DestinoAeroporto = existingDestinoAeroporto;

        _context.Voos.Add(voo);
        await _context.SaveChangesAsync();

        return Created("", voo);
    }
    [HttpPost]
    [Route("postMany")]
    public async Task<ActionResult> PostVoos(List<Voo> voos)
    {
        if (_context is null) return NotFound();

        try
        {
            foreach (var voo in voos)
            {
                var aviao = await _context.Avioes.FindAsync(voo.AviaoId);
                var aeroportoOrigem = await _context.Aeroportos.FindAsync(voo.OrigemAeroportoId);
                var aeroportoDestino = await _context.Aeroportos.FindAsync(voo.DestinoAeroportoId);
                var companhiaAerea = await _context.CompanhiasAereas.FindAsync(aviao.CompanhiaAereaId);

                if (aviao == null)
                {
                    return BadRequest($"Avião com ID {voo.AviaoId} não encontrado.");
                }

                if (companhiaAerea == null)
                {
                    return BadRequest($"Companhia com ID {voo.Aviao.CompanhiaAereaId} não encontrado.");
                }

                if (aeroportoOrigem == null)
                {
                    return BadRequest($"Aeroporto de Origem com ID {voo.OrigemAeroportoId} não encontrado.");
                }

                if (aeroportoDestino == null)
                {
                    return BadRequest($"Aeroporto de Destino com ID {voo.DestinoAeroportoId} não encontrado.");
                }

                if (aeroportoOrigem.Id == aeroportoDestino.Id)
                {
                    return BadRequest("O aeroporto de origem não pode ser o mesmo de destino.");
                }

                voo.Aviao = aviao;
                voo.Aviao.CompanhiaAerea = companhiaAerea;
                voo.OrigemAeroporto = aeroportoOrigem;
                voo.DestinoAeroporto = aeroportoDestino;
                _context.Voos.Add(voo);
            }

            await _context.SaveChangesAsync();
            return Ok("Voos adicionados com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar voos: {ex.Message}");
        }
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Voo voo)
    {
        if (_context is null) return NotFound();
        var aviao = await _context.Avioes.FindAsync(voo.AviaoId);
        var aeroportoOrigem = await _context.Aeroportos.FindAsync(voo.OrigemAeroportoId);
        var aeroportoDestino = await _context.Aeroportos.FindAsync(voo.DestinoAeroportoId);
        var companhiaAerea = await _context.CompanhiasAereas.FindAsync(aviao.CompanhiaAereaId);
        voo.Aviao = aviao;
        voo.Aviao.CompanhiaAerea = companhiaAerea;
        voo.OrigemAeroporto = aeroportoOrigem;
        voo.DestinoAeroporto = aeroportoDestino;
        _context.Voos.Update(voo);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudarnumero/{id}")]
    public async Task<ActionResult> MudarNumero(int id, [FromForm] string numero)
    {
        if (_context is null) return NotFound();
        if (_context.Voos is null) return NotFound();
        var funcionarioTemp = await _context.Voos.FindAsync(id);
        if (funcionarioTemp is null) return NotFound();
        funcionarioTemp.Numero = numero;
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Voos is null) return NotFound();
        var funcionarioTemp = await _context.Voos.FindAsync(id);
        if (funcionarioTemp is null) return NotFound();
        _context.Remove(funcionarioTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }
}