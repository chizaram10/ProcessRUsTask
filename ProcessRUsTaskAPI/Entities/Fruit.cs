namespace ProcessRUsTask.Entities
{
    public class Fruit
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }
}
