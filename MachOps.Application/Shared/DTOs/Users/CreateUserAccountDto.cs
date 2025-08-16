using System.ComponentModel.DataAnnotations;

namespace MachOps.Application.Shared.DTOs.Users;

public sealed class CreateUserAccountDto
{
    [Required(ErrorMessage = "Nome do usuário é obrigatório.")]
    [MaxLength(100, ErrorMessage = "Nome do usuário deve ter menos do que 100 caracteres.")]
    public string Name { get; }

    [Required(ErrorMessage = "Email do usuário é obrigatório.")]
    [MaxLength(100, ErrorMessage = "Email do usuário deve ter menos do que 254 caracteres.")]
    public string Email { get; }

    [Required(ErrorMessage = "Senha do usuário é obrigatório.")]
    [MaxLength(100, ErrorMessage = "Senha do usuário deve ter menos do que 100 caracteres.")]
    public string Password { get; }

    [Required(ErrorMessage = "Número de telefone do usuário é obrigatório.")]
    [MaxLength(100, ErrorMessage = "Número de telefone do usuário deve ter menos do que 20 caracteres.")]
    public string Phone { get; }

    [Required(ErrorMessage = "Nível de acesso do usuário é obrigatório.")]
    public string Role { get; }
}