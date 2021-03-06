using Gallaria.ApiClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gallaria.ApiClient.Helpers
{
    public static class InheritanceCastingHelper
    {
        /**
        * This extension helper method is trying to typecasts or rather convert PersonDto into ArtistDto
        **/
        public static ArtistDto ConvertIntoArtist(this PersonDto personDto)
        {
            var serializedPerson = JsonConvert.SerializeObject(personDto);

            ArtistDto artist = JsonConvert.DeserializeObject<ArtistDto>(serializedPerson);
            return artist;
        }
    }
}
