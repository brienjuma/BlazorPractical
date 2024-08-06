using BlazorPractical.Models;
using Dapper;

namespace BlazorPractical.Services;

public class PersonService
{
    private readonly DatabaseContext _dbContext;

    public PersonService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Person>> GetAllPeopleAsync()
    {
        var sql = "SELECT PersonId, FirstName, LastName FROM sp_people";

        using (var connection = _dbContext.DatabaseConnection())
        {
            return await connection.QueryAsync<Person>(sql);
        }

    }


}
