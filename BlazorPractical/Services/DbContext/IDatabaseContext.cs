using System.Data;

namespace BlazorPractical.Services.DbContext;

public interface IDatabaseContext
{
    IDbConnection DatabaseConnection();
}