namespace BlazorFullStackCrud.Client.Services.PersonService
{
    public interface IPersonService
    {
        List<Person> People { get; set; }

        Task GetPeople();

        Task<Person> GetSinglePerson(int id);

        Task CreatePerson(Person person);
        Task UpdatePerson(Person person);
        Task DeletePerson(int id);
    }
}
