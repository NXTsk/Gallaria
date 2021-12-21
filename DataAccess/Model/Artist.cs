using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Artist : Person
    {
        private int _artistId;
        public int ArtistId {
            get => _artistId;
            set
            {
                _artistId = value;
                Id = value;
            }
        }
        public string ProfileDescription { get; set; }

    }
}
