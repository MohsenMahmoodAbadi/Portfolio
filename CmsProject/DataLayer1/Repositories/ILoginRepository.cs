using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer1
{
    public interface ILoginRepository
    {
        bool IsUserExist(string username, string password);
    }
}
