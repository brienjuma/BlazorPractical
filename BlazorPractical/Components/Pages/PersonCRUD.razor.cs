using Microsoft.AspNetCore.Components;
using BlazorPractical.Models;

namespace BlazorPractical.Components.Pages
{
    public partial class PersonCRUD
    {
        [SupplyParameterFromForm(FormName = "Registration")]
        private Person Person { get; set; } = new();

        private IEnumerable<Person> people = [];

        protected override void OnInitialized() => Person ??= new Person();

        protected override async Task OnInitializedAsync() => await LoadDBRecordsAsync();

        private async Task LoadDBRecordsAsync() => people = await PersonService.GetAllAsync();

        private async Task HandleValidSubmit()
        {
            // Console.WriteLine(Person?.ToString() ?? "person == null");

            if (await PersonService.GetByIdAsync(Person.PersonId) != null)
            {
                await PersonService.UpdateAsync(Person);
            }
            else
            {
                await PersonService.AddAsync(Person);
            }

            await LoadDBRecordsAsync();
            Person = new Person();
        }

        public async Task EditPerson(string personId)
        {
            Person = await PersonService.GetByIdAsync(personId);
        }

        private async Task DeletePerson(string personId)
        {
            await PersonService.DeleteAsync(personId);
            await LoadDBRecordsAsync();
        }
    }
}