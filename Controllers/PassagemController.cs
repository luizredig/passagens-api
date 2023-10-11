using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class PassagemController : ControllerBase
{
    private APIDbContext? _context;
    public PassagemController(APIDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult<IEnumerable<Passagem>>> List()
    {
        if (_context is null) return NotFound();

        var passagens = await _context.Passagens
            .Include(a => a.Portao)
            .Include(a => a.Portao.Aeroporto)
            .Include(a => a.Voo)
            .Include(a => a.Voo.Aviao)
            .Include(a => a.Voo.Aviao.CompanhiaAerea)
            .Include(a => a.Voo.OrigemAeroporto)
            .Include(a => a.Voo.DestinoAeroporto)
            .Include(a => a.Passageiro)
            .Include(a => a.Pagamento)
            .ToListAsync();

        return passagens;
    }
    [HttpGet()]
    [Route("find/{id}")]
    public async Task<ActionResult<Passagem>> Find([FromRoute] int id)
    {
        if (_context is null) return NotFound();
        var passagemTemp = await _context.Passagens.FindAsync(id);
        if (passagemTemp is null) return NotFound();
        var vooTemp = await _context.Voos.FindAsync(passagemTemp.VooId);
        if (vooTemp is null) return NotFound();
        var aviaoTemp = await _context.Avioes.FindAsync(vooTemp.AviaoId);
        if (aviaoTemp is null) return NotFound();
        var companhiaTemp = await _context.CompanhiasAereas.FindAsync(aviaoTemp.CompanhiaAereaId);
        if (companhiaTemp is null) return NotFound();
        var aeroportoOrigemTemp = await _context.Aeroportos.FindAsync(vooTemp.OrigemAeroportoId);
        if (aeroportoOrigemTemp is null) return NotFound();
        var portaoTemp = await _context.Portoes.FindAsync(passagemTemp.PortaoId);
        if (portaoTemp is null) return NotFound();
        var aeroportoDestinoTemp = await _context.Aeroportos.FindAsync(vooTemp.DestinoAeroportoId);
        if (aeroportoDestinoTemp is null) return NotFound();
        var passageiroTemp = await _context.Passageiros.FindAsync(passagemTemp.PassageiroId);
        if (passageiroTemp is null) return NotFound();
        var pagamentoTemp = await _context.Pagamentos.FindAsync(passagemTemp.PagamentoId);
        if (pagamentoTemp is null) return NotFound();

        aviaoTemp.CompanhiaAerea = companhiaTemp;
        vooTemp.Aviao = aviaoTemp;
        vooTemp.OrigemAeroporto = aeroportoOrigemTemp;
        vooTemp.DestinoAeroporto = aeroportoDestinoTemp;
        portaoTemp.Aeroporto = aeroportoOrigemTemp;
        passagemTemp.Pagamento = pagamentoTemp;
        passagemTemp.Passageiro = passageiroTemp;
        passagemTemp.Portao = portaoTemp;
        passagemTemp.Voo = vooTemp;
        return passagemTemp;
    }
    [HttpPost]
    [Route("post")]
    public async Task<ActionResult<Passagem>> Post(Passagem passagem)
    {
        if (_context is null) return NotFound();
        // Verificar se o Voo existe pelo ID
        var existingVoo = await _context.Voos.FindAsync(passagem.VooId);
        if (existingVoo == null)
        {
            return BadRequest("Voo não encontrado.");
        }

        // Verificar se o Avião existe pelo ID
        var existingAviao = await _context.Avioes.FindAsync(existingVoo.AviaoId);
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
        var existingOrigemAeroporto = await _context.Aeroportos.FindAsync(existingVoo.OrigemAeroportoId);
        var existingDestinoAeroporto = await _context.Aeroportos.FindAsync(existingVoo.DestinoAeroportoId);
        if (existingOrigemAeroporto == null || existingDestinoAeroporto == null)
        {
            return BadRequest("Aeroporto de origem ou destino não encontrado.");
        }

        // Verificar se o Passageiro existe pelo ID
        var existingPassageiro = await _context.Passageiros.FindAsync(passagem.PassageiroId);
        if (existingPassageiro == null)
        {
            return BadRequest("Passageiro não encontrado.");
        }

        // Verificar se o Pagamento existe pelo ID
        var existingPagamento = await _context.Pagamentos.FindAsync(passagem.PagamentoId);
        if (existingVoo == null)
        {
            return BadRequest("Pagamento não encontrado.");
        }

        // Verificar se o Portao existe pelo ID
        var existingPortao = await _context.Portoes.FindAsync(passagem.PortaoId);
        if (existingPortao == null)
        {
            return BadRequest("Portao não encontrado.");
        }

        // Agora podemos criar a Passagem e relacioná-la aos objetos existentes

        existingAviao.CompanhiaAerea = existingCompanhiaAerea;
        existingVoo.Aviao = existingAviao;
        passagem.Voo = existingVoo;
        passagem.Passageiro = existingPassageiro;
        passagem.Pagamento = existingPagamento;
        existingPortao.Aeroporto = existingOrigemAeroporto;
        passagem.Portao = existingPortao;
        passagem.Voo.DestinoAeroporto = existingDestinoAeroporto;
        passagem.Voo.OrigemAeroporto = existingOrigemAeroporto;

        _context.Passagens.Add(passagem);
        await _context.SaveChangesAsync();

        return Created("", passagem);
    }
    [HttpPost]
    [Route("postMany")]
    public async Task<ActionResult> PostPassagens(List<Passagem> passagens)
    {
        if (_context is null) return NotFound();

        try
        {
            foreach (var passagem in passagens)
            {
                var pagamento = await _context.Pagamentos.FindAsync(passagem.PagamentoId);
                var voo = await _context.Voos.FindAsync(passagem.VooId);
                var portao = await _context.Portoes.FindAsync(passagem.PortaoId);
                var passageiro = await _context.Passageiros.FindAsync(passagem.PassageiroId);

                if (pagamento == null)
                {
                    return BadRequest($"Pagamento com ID {passagem.PagamentoId} não encontrado.");
                }

                if (voo == null)
                {
                    return BadRequest($"Voo com ID {passagem.VooId} não encontrado.");
                }

                if (passageiro == null)
                {
                    return BadRequest($"Passageiro com ID {passagem.PassageiroId} não encontrado.");
                }
                if (portao == null)
                {
                    return BadRequest($"Portao com ID {passagem.PortaoId} não encontrado.");
                }

                passagem.Voo = voo;
                passagem.Portao = portao;
                passagem.Passageiro = passageiro;
                passagem.Pagamento = pagamento;

                _context.Passagens.Add(passagem);
            }

            await _context.SaveChangesAsync();
            return Ok("Passagens adicionadas com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar passagens: {ex.Message}");
        }
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Passagem passagem)
    {
        if (_context is null) return NotFound();
        var pagamento = await _context.Pagamentos.FindAsync(passagem.PagamentoId);
        var voo = await _context.Voos.FindAsync(passagem.VooId);
        var portao = await _context.Portoes.FindAsync(passagem.PortaoId);
        var passageiro = await _context.Passageiros.FindAsync(passagem.PassageiroId);
        passagem.Voo = voo;
        passagem.Portao = portao;
        passagem.Passageiro = passageiro;
        passagem.Pagamento = pagamento;
        _context.Passagens.Update(passagem);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudarclasse/{id}")]
    public async Task<ActionResult> MudarClasse(int id, [FromForm] string classe)
    {
        if (_context is null) return NotFound();
        if (_context.Passagens is null) return NotFound();
        var passagemTemp = await _context.Passagens.FindAsync(id);
        if (passagemTemp is null) return NotFound();
        passagemTemp.Classe = classe;
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Passagens is null) return NotFound();
        var passagemTemp = await _context.Passagens.FindAsync(id);
        if (passagemTemp is null) return NotFound();
        _context.Remove(passagemTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }
}