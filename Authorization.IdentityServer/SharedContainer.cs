using Microsoft.Extensions.DependencyInjection;

using IdentityServer.Services.Services;
using Restaurant.DAL.Repositories;
using IdentityServer.Services.Interfaces;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Restaurant.DAL.Interfaces;
using Restaurant.Services.Interfaces;
using Restaurant.Services.Services;

namespace SharedDI
{
    public static class SharedContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // IdentityServer services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IAccountService, AccountService>();

            // Restaurant services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IDishPhotoRepository, DishPhotoRepository>();
            services.AddScoped<Restaurant.DAL.Interfaces.IUnitOfWork, Restaurant.DAL.UnitOfWork>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IDishService, DishService>();


            // Shared authorization policies and handlers
            //services.AddSingleton<IAuthorizationHandler, AgeRequirementHandler>();
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AlcoholAccess", policy =>
            //        policy.Requirements.Add(new AgeRequirement(18)));
            //});
        }
    }
}
