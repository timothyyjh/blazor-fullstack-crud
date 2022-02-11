namespace BlazorFullStackCrud.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    FirstName = "Timothy",
                    LastName = "Yeo",
                    EmailAddress = "timothyyjh@gmail.com"
                },

                new Person
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "johndoe@gmail.com"
                }
            );
        }

        public DbSet<Person> People { get; set; }
    }
}
