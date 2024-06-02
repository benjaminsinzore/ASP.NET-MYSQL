using Libs;
using Models;

namespace Services
{
    public class SecurityService : SecurityImplService
    {
 
        public string GetUserById()
        {
            return SystemTools.GetUserById();

        }


    }
}
