using Microsoft.EntityFrameworkCore;
using web_api.models;

namespace web_api.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DbContext _context;

        private readonly IConfiguration _configuration;


        public AuthRepository(DbContext context , IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

     


        public async Task<ServiceResponse<int>> Register(User request)
        {
            
        }

    }
}