using ProcessRUsTask.DTOs;

namespace ProcessRUsTask.Services
{
    public interface IAuthService
    {
        Task<(int, string)> Login(LoginDTO model);
    }
}