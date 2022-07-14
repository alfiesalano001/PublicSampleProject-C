using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public interface IAuthJWToken
    {
        string CreateJWToken(string username, string passowrd);    
    }
   
}
