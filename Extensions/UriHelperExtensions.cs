﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameX.Controllers;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            //return urlHelper.Action(
            //    action: nameof(LoginController.ConfirmEmail),
            //    controller: "Account",
            //    values: new { userId, code },
            //    protocol: scheme);
            return "";
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            //return urlHelper.Action(
            //    action: nameof(AccountController.ResetPassword),
            //    controller: "Account",
            //    values: new { userId, code },
            //    protocol: scheme);
            return "";
        }
    }
}