using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.ApiResponses
{
    public class CreateOrderApiResponse
    {
        public bool hasBeenCreated { get; set; }
        public int OrderId { get; set; }
    }
}
