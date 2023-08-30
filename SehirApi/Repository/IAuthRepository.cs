﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SehirApi.Models;

namespace SehirApi.Repository
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}
