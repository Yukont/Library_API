﻿using Library_API.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_API.BLL.Interfaces
{
    public interface IUserService
    {
        Task<string> Authenticate(string username, string password);
    }
}
