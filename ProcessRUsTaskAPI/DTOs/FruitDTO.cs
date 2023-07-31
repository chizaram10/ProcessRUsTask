namespace ProcessRUsTask.DTOs
{
    public record FruitDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
