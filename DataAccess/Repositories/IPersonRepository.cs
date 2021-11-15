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
        int CreatePerson(Person person, string password);
        bool DeletePerson(int id);
        int Login(string email, string password);
        bool UpdatePassword(string email, string oldPassword, string newPassword);

    }
}
