using MediFlow.API.Shared;
using System.Security.Claims;

namespace MediFlow.API.Modules.Dummy.UseCases.Test1;

public record Test1Request(
    string someData,
    ClaimsPrincipal user) : IHttpRequest;
