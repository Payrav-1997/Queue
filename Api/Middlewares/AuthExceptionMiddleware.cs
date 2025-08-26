// using System.Net;
// using Domain.Models.Entities;
// using Microsoft.AspNetCore.Identity;
//
// namespace Api.Middlewares;
//
// public class AuthExceptionMiddleware(
//     RequestDelegate next,
//     UserManager<User> userManager,
//     IRolePermissionRepository rolePermissionRepository,
//     RoleManager<IdentityRole<Guid>> roleManager)
// {
//
//     public async Task InvokeAsync(HttpContext context)
//     {
//         var user = await userManager.GetUserAsync(context.User);
//
//         if (user != null)
//         {
//             var requestPath = context.Request.Path.Value;
//             var requestMethod = context.Request.Method;
//
//             if (!await HasAccess(user, requestPath, requestMethod))
//             {
//                 context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
//                 await context.Response.WriteAsync("Access denied");
//                 return;
//             }
//         }
//
//         await next(context);
//     }
//
//     private async Task<bool> HasAccess(User user, string? path, string method)
//     {
//         var userRoleNames = await userManager.GetRolesAsync(user);
//         var userRoleIds = new List<Guid>();
//
//         foreach (var roleName in userRoleNames)
//         {
//             var role = await roleManager.FindByNameAsync(roleName);
//             if (role != null)
//             {
//                 userRoleIds.Add(role.Id);
//             }
//         }
//
//         var permissions = await rolePermissionRepository.GetPermissionsForRoles(userRoleIds);
//
//         return permissions.Any(permission => path != null && path.Contains(permission.Role.Controller) && method.Equals(permission.Role.Action, StringComparison.OrdinalIgnoreCase));
//     }
// }