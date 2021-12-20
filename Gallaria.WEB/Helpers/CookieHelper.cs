﻿using Gallaria.ApiClient.DTOs;
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
        public static void SaveJWTAsCookie(string key, AuthUserDto userData, HttpResponse response)
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
