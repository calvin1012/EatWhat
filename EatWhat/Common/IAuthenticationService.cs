﻿using System.Threading.Tasks;

namespace EatWhat.Common
{
    public interface IAuthenticationService
    {
        bool IsSignIn();
        Task<bool> CreateUser(string username, string email, string password);
        void SignOut();
        Task<string> SignIn(string email, string password);
        Task ResetPassword(string email);
    }
}