using Gallaria.ApiClient.ApiResponses;
using Gallaria.ApiClient.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.WEB.Helpers
{
    public class CookieHelper
    {
        public static void SaveJWTAsCookie(string key, AuthenticatedUserData userData, HttpResponse response)
        {
            CookieOptions option = new CookieOptions();

            option.Expires = userData.Expiration;

            response.Cookies.Append(key, userData.Token, option);
        }

        public static string ReadJWT(string key, IHttpContextAccessor contextAccessor)
        {
            string jwtToken = contextAccessor.HttpContext.Request.Cookies[key];

            return jwtToken;
        }
        public static void RemoveJWT(string key, HttpResponse response)
        {
            response.Cookies.Delete(key);
        }

    }
}
