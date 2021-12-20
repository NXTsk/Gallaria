using Gallaria.ApiClient.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.WEB.Helpers
{
    public static class CookieHelper
    {
        public static void SaveJWTAsCookie(AuthUserDto userData, HttpResponse response)
        {
            CookieOptions option = new CookieOptions();

            option.Expires = userData.Expiration;

            response.Cookies.Append("X-Access-Token", userData.Token, option);
        }

        public static string ReadJWT(IHttpContextAccessor contextAccessor)
        {
            string jwtToken = contextAccessor.HttpContext.Request.Cookies["X-Access-Token"];

            return jwtToken;
        }
        public static void RemoveJWT(HttpResponse response)
        {
            response.Cookies.Delete("X-Access-Token");
        }

        public static void SaveCookie(string key, string data, HttpResponse response)
        {
            CookieOptions option = new CookieOptions();

            option.Expires = DateTime.Now.AddMonths(1);
            response.Cookies.Append(key, data, option);
        }

        public static string ReadCookie(string key, IHttpContextAccessor contextAccessor)
        {
            string cookie = contextAccessor.HttpContext.Request.Cookies[key];

            return cookie;
        }

        public static void RemoveCookie(string key, HttpResponse response)
        {
            response.Cookies.Delete(key);
        }
    }
}
