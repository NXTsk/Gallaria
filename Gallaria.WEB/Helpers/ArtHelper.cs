using Gallaria.ApiClient.DTOs;
using Gallaria.ApiClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallaria.WEB.Helpers
{
    public static class ArtHelper
    {
        public static string GetImageSourceFromByteArray(byte[] imgBytes)
        {
            string imreBase64Data = Convert.ToBase64String(imgBytes);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            return imgDataURL;
        }
        public static string GetAuthorName(ArtDto art, IPersonClient _personClient)
        {
            var artist = _personClient.GetPersonByIdAsync(art.AuthorId).Result;
            return (artist.FirstName + " " + artist.LastName);
        }
    }
}
