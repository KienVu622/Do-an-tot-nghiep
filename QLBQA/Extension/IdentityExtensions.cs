﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
//Lấy thông tin cần khi login
namespace QLBQA.Extension
{
    public static class IdentityExtensions
    {
        public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}