﻿using Microsoft.Extensions.DependencyInjection;

namespace JPProject.Admin.Api.Configuration
{
    public static class ConfigurePolicy
    {
        public static void AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    policy => policy.RequireAssertion(c =>
                        c.User.HasClaim("is4-rights", "manager") ||
                        c.User.IsInRole("Administrator")));

                options.AddPolicy("ReadOnly", policy =>
                    policy.RequireAssertion(context => context.User.Identity != null && context.User.Identity.IsAuthenticated));

                options.AddPolicy("UserManagement", policy =>
                    policy.RequireAuthenticatedUser());
            });

        }
    }
}
