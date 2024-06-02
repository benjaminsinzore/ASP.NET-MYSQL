using Microsoft.AspNetCore.Identity;
using Models;

namespace Services
{
    public class SecurityRoute
    {
        SecurityImplService implService = new SecurityService();

        public string GetUserById()
        {
           return implService.GetUserById();
        }

        
    }
}
