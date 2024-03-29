﻿using Microsoft.AspNetCore.Identity;

namespace KzTrail.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
