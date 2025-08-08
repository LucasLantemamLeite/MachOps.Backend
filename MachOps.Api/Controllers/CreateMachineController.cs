using MachOps.Application.Interfaces.Handlers;
using MachOps.Application.Shared.DTOs;
using MachOps.Application.Shared.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace MachOps.Api.Controllers;

[ApiController]
[Route("v1")]
[Tags("Machines")]
public sealed class CreateMachineController : ControllerBase
{
    private readonly ICreateMachineHandler _handler;

    public CreateMachineController(ICreateMachineHandler handler) => _handler = handler;

    [HttpPost("machine")]
    public async Task<IActionResult> CallRequestAsync(CreateMachineDto machineDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultHandler = await _handler.Handle(machineDto);

            if (!resultHandler.Success)
                return BadRequest(new { resultHandler.Message });

            return Ok(new { resultHandler.Message, Data = resultHandler.Data?.ToSingleMachineEntityRaw() });
        }

        catch
        {
            return StatusCode(500, new { Message = "Erro interno no servidor, tente novamente mais tarde." });
        }
    }
}