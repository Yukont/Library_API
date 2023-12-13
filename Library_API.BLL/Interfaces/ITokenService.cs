using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(int userId, string username);
    }
}
