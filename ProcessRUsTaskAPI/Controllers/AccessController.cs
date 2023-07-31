using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProcessRUsTask.DTOs;
using ProcessRUsTask.Extensions;
using ProcessRUsTask.Infrastructure.Respositories;

namespace ProcessRUsTask.Controllers
{
    [ApiController]
    [Route("access")]
    public class AccessController : ControllerBase
    {
        private readonly IFruitRepository _fruitRepository;

        public AccessController(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }

        // GET: api/access
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<FruitDTO>> GetAsync()
        {
            return (await _fruitRepository.GetAllAsync())
                .Select(fruit => fruit.AsDTO());
        }
    }
}
