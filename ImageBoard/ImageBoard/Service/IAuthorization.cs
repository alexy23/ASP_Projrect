using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageBoard.Service
{
    public interface IAuthorization
    {
        string HashFunction(string password, string Salt);
        string GenerateSalt(int Length = 16);

    }
}
