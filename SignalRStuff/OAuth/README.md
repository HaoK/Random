# SignalR OAuth

This app demonstrates using google/twitter to do basic authentication.

- You will need to setup the OAuth apps with Google/Twitter and add the credentials to your user secrets/config.
```C#
            // Setup via https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/?view=aspnetcore-2.1
            // Add keys with the right client/appId/secret keys to your user secrets
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.LoginPath = "/ExternalLogin")
                .AddGoogle(o => Configuration.GetSection("authentication:google").Bind(o))
                .AddTwitter(o => Configuration.GetSection("authentication:twitter").Bind(o));
```

- Flow: /Home -> /Chat -> /ExternalLogin -> external Twitter/Google -> /Chat 
- You can verify via incognito and a normal browser that twitter, google sign ins work and can chat with each other successfully
