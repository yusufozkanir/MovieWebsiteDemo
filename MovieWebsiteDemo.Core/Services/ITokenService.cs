using MovieWebsiteDemo.Core.Configurations;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebsiteDemo.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);

        ClientTokenDto CreateTokenByClient(Client client);
    }
}
