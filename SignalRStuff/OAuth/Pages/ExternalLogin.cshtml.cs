// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth.Pages
{
    public class ExternalLoginModel : PageModel
    {
        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public ExternalLoginModel(IAuthenticationSchemeProvider schemes)
        {
            _schemes = schemes;
        }

        private IAuthenticationSchemeProvider _schemes;

        public async Task OnGetAsync(string returnUrl = null)
        {
            ExternalLogins = (await _schemes.GetAllSchemesAsync())
                .Where(s => !string.IsNullOrEmpty(s.DisplayName)).ToList();

            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            var properties = new AuthenticationProperties();
            if (returnUrl != null)
            {
                properties.RedirectUri = returnUrl;
            }
            return new ChallengeResult(provider, properties);
        }

    }
}
