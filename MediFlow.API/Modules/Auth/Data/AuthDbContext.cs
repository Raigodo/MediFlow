using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediFlow.API.Modules.Auth.Data;

public class AuthDbContext(DbContextOptions options) : IdentityDbContext(options)
{

}
