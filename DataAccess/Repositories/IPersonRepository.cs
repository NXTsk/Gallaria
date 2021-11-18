using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IPersonRepository
    {
        Task<int> CreatePersonAsync(Person person, string password);
        Task<bool> DeletePersonAsync(int id);
        int Login(string email, string password);
        Task<bool> UpdatePasswordAsync(string email, string oldPassword, string newPassword);

    }
}
