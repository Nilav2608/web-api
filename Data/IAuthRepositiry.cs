using web_api.models;

namespace web_api.Data
{
    public interface IAuthRepositiry
    {
         Task<ServiceResponse<int>> Register(User request);
    }
}