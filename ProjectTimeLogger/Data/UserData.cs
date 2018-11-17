using Microsoft.AspNetCore.Http;
using ProjectTimeLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeLogger.Data
{
    public class UserData : IUserData
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserData(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetID()
        {
            var email = _httpContextAccessor.HttpContext.User.Identity.Name;
            using (var db = new postgresContext())
            {
                return db.AspNetUsers.Single(x => x.Email == email).Id;
            }
        }
    }
}
