// using Microsoft.AspNetCore.Mvc;

// namespace server.Controllers;

// [ApiController]
// [Route("v1/[controller]")]
// public class UsuarioController : ControllerBase
// {

//     private readonly EmailServiceImpl _emailService;

//     public UsuarioController(
//             EmailServiceImpl emailService
//         ) {
//             _emailService = emailService;
//     }


//     [HttpPost("CadastrarUsuarioAsync")]
//     public async Task<IActionResult> CadastrarUsuarioAsync() {
//         _emailService.SendMail();
        
//         return Ok();
//     }
// }