using MachOps.Application.Interfaces.Handlers.Users;
using MachOps.Application.Shared.DTOs.Users;
using MachOps.Application.Shared.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachOps.Api.Controllers.Users;

[ApiController]
[Route("v1")]
[Tags("Users")]
public sealed class CreateUserAccountController(ICreateUserAccountHandler handler) : ControllerBase
{
    private readonly ICreateUserAccountHandler _handler = handler;

    [HttpPost("user")]
    public async Task<IActionResult> Create([FromBody] CreateUserAccountDto userDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _handler.Handle(userDto);

            if (!result.Success)
                return BadRequest(new { result.Message });

            return Ok(new { result.Message, tokenKey = result.Data?.ToSingleUserAccountRaw() });
        }

        catch
        {
            return StatusCode(500, new { Message = "Erro interno no servidor. Tente novamente mais tarde." });
        }
    }
}