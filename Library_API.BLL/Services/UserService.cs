using Library_API.BLL.DTO;
using Library_API.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly ITokenService tokenService;
        public UserService(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }
        private readonly List<UserDTO> users = new List<UserDTO>
        {
            new UserDTO { Id = 1, Username = "user1", Password = "password1" },
            new UserDTO { Id = 2, Username = "user2", Password = "password2" }
        };

        public async Task<string> Authenticate(string username, string password)
        {
            var user = users.SingleOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return null;
            }
            string token = await tokenService.GenerateToken(user.Id, user.Username);

            return await Task.FromResult(token);
        }
    }
}
