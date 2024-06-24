using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Services
{
    public interface IAuthService
    {
        //authenticação jwt
        //vai retornar uma stringonaaaa
        string GenerateJwtToken(string email, string role);
        string ComputeSha256Hash(string password);
    }
}
