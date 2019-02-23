﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class MyIdentityDataService
    {
        public const string AdminRoleName = "Admin";
        public const string EditorRoleName = "Editor";
        public const string ContributorRoleName = "Contributor";

        public const string BlogPolicy_Add = "CanAddBlogPosts";
        public const string BlogPolicy_Edit = "CanEditBlogPosts";
        public const string BlogPolicy_Delete = "CanDeleteBlogPosts";

        internal static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            foreach(var roleName in new[] { AdminRoleName, EditorRoleName, ContributorRoleName })
            {
                var role = roleManager.FindByNameAsync(roleName).Result;
                if(role == null)
                {
                    role = new IdentityRole(roleName);
                    //Ask about what this does.
                    roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }
            }
            foreach (var userName in new[] { "admin@snow.edu", "editor@snow.edu", "contributor@snow.edu" })
            {
                var user = userManager.FindByNameAsync(userName).Result;
                if(user == null)
                {
                    user = new IdentityUser(userName)
                    {
                        Email = userName
                    };
                    userManager.CreateAsync(user, "Abc123!").GetAwaiter().GetResult();
                  
                }
                if (userName.StartsWith("admin")){
                    userManager.AddToRoleAsync(user, AdminRoleName).GetAwaiter().GetResult();
                }
                if (userName.StartsWith("editor"))
                {
                    userManager.AddToRoleAsync(user, EditorRoleName).GetAwaiter().GetResult();
                }
                if (userName.StartsWith("contributor"))
                {
                    userManager.AddToRoleAsync(user, ContributorRoleName).GetAwaiter().GetResult();
                }

            }
        }
    
    }
}
