using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IArtRepository
    {
        Task<int> CreateArtAsync(Art art);
        Task<bool> DeleteArtAsync(int id);
        Task<Art> GetArtByIDAsync(int id);
        Task<IEnumerable<Art>> GetAllArtsThatByAuthorIdAsync(int authorId);
        Task<IEnumerable<Art>> GetAllArtsAsync();
        Task<IEnumerable<Art>> GetAllAvailableArtsAsync();
        Task<int> UpdateArtQuantityById(int id, int updatedQuantity);
        Task<bool> UpdateArtAsync(Art art);
    }
}
