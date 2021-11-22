using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Artist : Person
    {
        public int ArtistId { get; set; }
        public string ProfileDescription { get; set; }

    }
}
