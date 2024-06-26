﻿using Microsoft.AspNetCore.Authorization;
using MinimalApiCatalogo.Models;
using MinimalApiCatalogo.Services;
using System.Runtime.CompilerServices;

namespace MinimalApiCatalogo.ApiEndpoints
{
    public static class AutenticacaoEndpoints
    {
        public static void MapAutenticacaoEndpoints(this WebApplication app) 
        {
            app.MapPost("/login", [AllowAnonymous] (UserModel userModel, ITokenService tokenService) =>
            {
                if (userModel == null) return Results.BadRequest("Login Inválido");

                if (userModel.UserName == "Th" && userModel.Password == "myP@ssw0rd")
                {
                    var tokenString = tokenService.GerarToken(app.Configuration["Jwt:Key"],
                        app.Configuration["Jwt:Issuer"],
                        app.Configuration["Jwt:Audience"],
                        userModel);
                    return Results.Ok(new { token = tokenString });
                };

                return Results.BadRequest("Login Inválido");
            }).Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithName("Login")
            .WithTags("Autenticacao");
        }
    }
}
