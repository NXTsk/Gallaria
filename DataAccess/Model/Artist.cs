using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Artist : Person
    {
        private int artistId;
        public int ArtistId {
            get => artistId;
            set
            {
                artistId = value;
                Id = value;
            }
        }
        public string ProfileDescription { get; set; }

    }
}
