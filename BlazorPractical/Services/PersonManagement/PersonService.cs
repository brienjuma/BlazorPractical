using BlazorPractical.Models;
using BlazorPractical.Services.DbContext;
using Dapper;

namespace BlazorPractical.Services.PersonManagement;

public class PersonService(IDatabaseContext dbContext) : IPersonService
{
    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        const string sql = "SELECT PersonId, FirstName, LastName FROM sp_people";

        using (var connection = dbContext.DatabaseConnection())
        {
            return await connection.QueryAsync<Person>(sql);
        }
    }

    public async Task AddAsync(Person person)
    {
        const string sql = "INSERT INTO sp_people(PersonId, FirstName, LastName) VALUES(@PersonId, @FirstName, @LastName)";
        using (var connection = dbContext.DatabaseConnection())
        {
            await connection.ExecuteAsync(sql, person);
        }
    }

    public async Task<Person> GetByIdAsync(string id)
    {
        const string sql = "SELECT PersonId, FirstName, LastName FROM sp_people WHERE PersonId = @PersonId";

        using (var connection = dbContext.DatabaseConnection())
        {
            return await connection.QuerySingleOrDefaultAsync<Person>(sql, new { PersonId = id });
        }
    }

    public async Task UpdateAsync(Person person)
    {
        const string sql = "UPDATE sp_people SET FirstName = @FirstName, LastName = @LastName WHERE PersonId = @PersonId";
        using (var connection = dbContext.DatabaseConnection())
        {
            await connection.ExecuteAsync(sql, person);
        }
    }

    public async Task DeleteAsync(string id)
    {
        const string sql = "DELETE FROM sp_people WHERE PersonId = @PersonId";
        using (var connection = dbContext.DatabaseConnection())
        {
            await connection.ExecuteAsync(sql, new { PersonId = id });
        }
    }
}
