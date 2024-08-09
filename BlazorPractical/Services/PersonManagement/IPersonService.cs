using BlazorPractical.Models;

namespace BlazorPractical.Services.PersonManagement
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task AddAsync(Person person);
        Task<Person> GetByIdAsync(string id);
        Task UpdateAsync(Person person);
        Task DeleteAsync(string id);
    }
}
