using web_api.models;

namespace web_api.Data
{
    public interface IAuthRepository
    {
         Task<ServiceResponse<int>> Register(User request);
    }
}