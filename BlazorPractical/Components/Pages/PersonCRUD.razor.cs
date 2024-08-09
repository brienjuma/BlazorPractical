using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using static Microsoft.AspNetCore.Components.Web.RenderMode;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using BlazorPractical;
using BlazorPractical.Components;
using BlazorPractical.Models;
using BlazorPractical.Services.PersonManagement;

namespace BlazorPractical.Components.Pages
{
    public partial class PersonCRUD
    {
        [SupplyParameterFromForm(FormName = "Registration")]
        public Person Person { get; set; }

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