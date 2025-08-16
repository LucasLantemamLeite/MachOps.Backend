using System.ComponentModel.DataAnnotations;

namespace MachOps.Application.Shared.DTOs;

public sealed class CreateMachineryDto
{
    [Required(ErrorMessage = "O campo Name é obrigatório.")]
    [MaxLength(30, ErrorMessage = "O campo Name não pode ter mais de 30 caracteres.")]
    public string MachineryName { get; init; }

    [Required(ErrorMessage = "O campo MachType é obrigatório.")]
    [Range(1, 6, ErrorMessage = "MachType inválido.")]
    public int MachineryType { get; init; }

    [Required(ErrorMessage = "O campo Status é obrigatório.")]
    [Range(1, 3, ErrorMessage = "Status inválido.")]
    public int MachineryStatus { get; init; }

    [MaxLength(20, ErrorMessage = "O campo de Location não pode ter menos de 20 caracteres.")]
    public string? MachineryLocation { get; init; }

    [MaxLength(100, ErrorMessage = "O campo de Description deve ter menos de 100 caracteres.")]
    public string? MachineryDescription { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "MaintenanceStartDate Inválido.")]
    public DateTime? MaintenanceStartDate { get; init; }

    [DataType(DataType.DateTime, ErrorMessage = "ExpectedReturnDate Inválido.")]
    public DateTime? ExpectedReturnDate { get; init; }
}