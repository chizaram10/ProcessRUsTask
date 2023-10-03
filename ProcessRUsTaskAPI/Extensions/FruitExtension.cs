using ProcessRUsTask.DTOs;
using ProcessRUsTask.Entities;

namespace ProcessRUsTask.Extensions
{
    public static class FruitExtension
    {
        public static FruitDTO AsDTO(this Fruit fruit)
        {
            return new FruitDTO(fruit.Id, fruit.Name);
        }
    }
}
