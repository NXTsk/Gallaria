using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.ApiResponses
{
    public class AuthenticatedUserData
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
    }
}
