namespace WebApi.Database
{
    using Domain;
    using System.Collections.Generic;

    public class Repository
    {
        public List<Todo> Todos { get; } = new List<Todo>()
        {
            new() { Id = 1 , Name="Call mother", Completed = false},
            new() { Id = 2, Name ="Cook dinner", Completed = false }
        };
    }
}
