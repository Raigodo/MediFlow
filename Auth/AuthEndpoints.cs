﻿using Account.Features.Login;
using Account.Features.RefreshToken;
using Account.Features.Register;
using Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Account;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);
        app.MapPost("login", Login);
        app.MapPost("refresh", RefrshToken);

        return app;
    }

    private record RegisterDto(string name, string email, string password);
    private static async Task<IResult> Register(RegisterDto req,
        [FromServices] ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new RegisterRequest(req.name, req.email, req.password));
        return Results.Ok(result);
    }

    private record LoginDto(string email, string password);
    private static async Task<IResult> Login(LoginDto req,
        IMediator sender, CancellationToken ct)
    {
        var result = await sender.Send(new LoginRequest(req.email, req.password), ct);
        return Results.Ok(result);
    }

    private record RefreshTokenDto(string refreshToken);
    private static async Task<IResult> RefrshToken(RefreshTokenDto req,
        ISender sender, CancellationToken ct)
    {
        var result = await sender.Send(new RefrestTokenRequest(req.refreshToken));
        if (result is null)
            return Results.BadRequest();
        return Results.Ok(result);
    }
}
