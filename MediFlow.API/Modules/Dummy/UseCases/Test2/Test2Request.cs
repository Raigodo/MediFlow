using MediFlow.API.Shared;
using System.Security.Claims;

namespace MediFlow.API.Features.Dummy.UseCases.Test1;

public record Test2Request(
    string someData,
    ClaimsPrincipal user) : IHttpRequest;
