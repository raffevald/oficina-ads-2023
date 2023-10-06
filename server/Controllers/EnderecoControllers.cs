using Microsoft.AspNetCore.Mvc;

namespace server.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class EnderecoControllers : ControllerBase
{

    private readonly IEnderecoService _enderecoService;

    public EnderecoControllers(
            IEnderecoService enderecoService
        ) {
            _enderecoService = enderecoService;
    }


    [HttpPost("CadastrarEnderecoAsync")]
    public async Task<IActionResult> CadastrarEnderecoAsync( Enderecos request ) {
        var endereco = await _enderecoService.CadastrarEnderecoAsync( request );
        return Ok(endereco);
    }

    [HttpGet("GetAllEnderecosAsync")]
    public async Task<IActionResult> GetAllEnderecosAsync() {
        var enderecos = await _enderecoService.GetAllEnderecosAsync();
        return Ok( enderecos );
    }

    [HttpGet("GetEnderecoByIdAsync/{idEndereco}")]
    public async Task<IActionResult> GetEnderecoByIdAsync( int idEndereco ) {
        var endereco = await _enderecoService.GetEnderecoByIdAsync( idEndereco );
        return Ok( endereco );
    }

    [HttpPut("UpdateEnderecoByIdAsync")]
    public async Task<IActionResult> UpdateEnderecoByIdAsync( Enderecos request ) {
        var endereco = await _enderecoService.UpdateEnderecoByIdAsync( request );
        return Ok( endereco );
    }

    [HttpDelete("DeleteEnderecoByIdAsync")]
    public async Task<IActionResult> DeleteEnderecoByIdAsync( int? idEndereco ) {
        bool success = await _enderecoService.DeleteEnderecoByIdAsync( idEndereco );
        // return Ok( new { success } );

        if ( success ) {
            return Ok("Endereço deletado com sucesso.");
        }

        return Ok("Erro ao deletar o endereço.");
    }
}
