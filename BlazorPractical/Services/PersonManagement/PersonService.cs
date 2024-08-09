using BlazorPractical.Models;
using BlazorPractical.Services.DbContext;
using Dapper;

namespace BlazorPractical.Services.PersonManagement;

public class PersonService : IPersonService
{
    private readonly DatabaseContext _dbContext;

    public PersonService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        var sql = "SELECT PersonId, FirstName, LastName FROM sp_people";

        using (var connection = _dbContext.DatabaseConnection())
        {
            return await connection.QueryAsync<Person>(sql);
        }
    }

    public async Task AddAsync(Person person)
    {
        var sql = "INSERT INTO sp_people(PersonId, FirstName, LastName) VALUES(@PersonId, @FirstName, @LastName)";
        using (var connection = _dbContext.DatabaseConnection())
        {
            await connection.ExecuteAsync(sql, person);
        }
    }

    public async Task<Person> GetByIdAsync(string id)
    {
        var sql = "SELECT PersonId, FirstName, LastName FROM sp_people WHERE PersonId = @PersonId";

        using (var connection = _dbContext.DatabaseConnection())
        {
            return await connection.QuerySingleOrDefaultAsync<Person>(sql, new { PersonId = id });
        }
    }

    public async Task UpdateAsync(Person person)
    {
        var sql = "UPDATE sp_people SET FirstName = @FirstName, LastName = @LastName WHERE PersonId = @PersonId";
        using (var connection = _dbContext.DatabaseConnection())
        {
            await connection.ExecuteAsync(sql, person);
        }
    }

    public async Task DeleteAsync(string id)
    {
        var sql = "DELETE FROM sp_people WHERE PersonId = @PersonId";
        using (var connection = _dbContext.DatabaseConnection())
        {
            await connection.ExecuteAsync(sql, new { PersonId = id });
        }
    }
}
