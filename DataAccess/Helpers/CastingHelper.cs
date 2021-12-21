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
        /**
         * This extension helper method is trying to typecasts or rather convert Person into Artist
         **/
        public static Artist ConvertIntoArtist(this Person person)
        {
            var serializedPerson = JsonConvert.SerializeObject(person);

            Artist artist = JsonConvert.DeserializeObject<Artist>(serializedPerson);
            return artist;
        }
    }
}
