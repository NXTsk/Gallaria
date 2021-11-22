using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IArtRepository
    {
        Task<int> CreateArtAsync(Art art);
        Task<bool> DeleteArtAsync(int id);
    }
}
