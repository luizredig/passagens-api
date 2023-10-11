using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{
    private APIDbContext? _context;
    public FuncionarioController(APIDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> List()
    {
        if (_context is null) return NotFound();

        var funcionarios = await _context.Funcionarios
            .Include(a => a.Aeroporto)
            .ToListAsync();

        return funcionarios;
    }
    [HttpGet()]
    [Route("find/{id}")]
    public async Task<ActionResult<Funcionario>> Find([FromRoute] int id)
    {
        if (_context is null) return NotFound();
        var funcionarioTemp = await _context.Funcionarios.FindAsync(id);
        if (funcionarioTemp is null) return NotFound();
        var aeroportoTemp = await _context.Aeroportos.FindAsync(funcionarioTemp.AeroportoId);
        if (aeroportoTemp is null) return NotFound();
        funcionarioTemp.Aeroporto = aeroportoTemp;
        return funcionarioTemp;
    }
    [HttpPost]
    [Route("post")]
    public async Task<ActionResult<Funcionario>> Post(Funcionario funcionario)
    {
        // Verificar se o Aeroporto já existe no banco de dados pelo ID
        var existingAeroporto = await _context.Aeroportos.FindAsync(funcionario.AeroportoId);

        if (existingAeroporto != null)
        {
            // Se o Aeroporto já existe, apenas relacione-o com o FuncionarioAeroporto
            funcionario.Aeroporto = existingAeroporto;
        }
        else
        {
            return BadRequest("Aeroporto não encontrado.");
        }

        // Adicione o FuncionarioAeroporto ao contexto e salve as alterações
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();

        return Created("", funcionario);
    }
    [HttpPost]
    [Route("postMany")]
    public async Task<ActionResult> PostFuncionarios(List<Funcionario> funcionarios)
    {
        if (_context is null) return NotFound();

        try
        {
            foreach (var funcionario in funcionarios)
            {
                var aeroporto = await _context.Aeroportos.FindAsync(funcionario.AeroportoId);

                if (aeroporto == null)
                {
                    return BadRequest($"Aeroporto com ID {funcionario.AeroportoId} não encontrado.");
                }

                _context.Funcionarios.Add(funcionario);
            }

            await _context.SaveChangesAsync();
            return Ok("Funcionários adicionados com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar funcionários: {ex.Message}");
        }
    }
    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario funcionario)
    {
        if (_context is null) return NotFound();
        var aeroporto = await _context.Aeroportos.FindAsync(funcionario.AeroportoId);
        if (aeroporto is null) return NotFound();
        funcionario.Aeroporto = aeroporto;
        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpPatch()]
    [Route("mudarcargo/{id}")]
    public async Task<ActionResult> MudarCargo(int id, [FromForm] string cargo)
    {
        if (_context is null) return NotFound();
        if (_context.Funcionarios is null) return NotFound();
        var funcionarioTemp = await _context.Funcionarios.FindAsync(id);
        if (funcionarioTemp is null) return NotFound();
        funcionarioTemp.Cargo = cargo;
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Funcionarios is null) return NotFound();
        var funcionarioTemp = await _context.Funcionarios.FindAsync(id);
        if (funcionarioTemp is null) return NotFound();
        _context.Remove(funcionarioTemp);
        await _context.SaveChangesAsync();
        return Ok();
    }
}