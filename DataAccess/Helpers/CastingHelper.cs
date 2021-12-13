using DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helpers
{
    public static class CastingHelper
    {
        public static Artist ConvertIntoArtist(this Person person)
        {
            var serializedPerson = JsonConvert.SerializeObject(person);

            Artist artist = JsonConvert.DeserializeObject<Artist>(serializedPerson);
            return artist;
        }
    }
}
