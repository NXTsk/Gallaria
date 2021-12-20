using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.DTOs
{
    public class AuthUserDto
    {
        /*-------API Response-------*/
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }

        /*-------Another variables-------*/
        public bool IsUserAuthenticated { get; set; }
    }
}
