using System.ComponentModel.DataAnnotations;

namespace ProcessRUsTask.DTOs
{
    public record LoginDTO
    {
        [Required]
        public string Username { get; set; } = string.Empty;
    }
}
