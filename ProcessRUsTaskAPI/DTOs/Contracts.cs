using System.ComponentModel.DataAnnotations;

namespace ProcessRUsTask.DTOs
{
    public record FruitDTO(Guid Id, string Name);
    public record LoginDTO([Required] string Username);
}
