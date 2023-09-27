using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Database;
using static WebApi.Dtos;

namespace WebApi.Queries
{
    public static class GetToDoById
    {
        //Query or command
        //All the data we need to execute
        public record GetTodoByIdQuery(int Id) : IRequest<Response>;

        //handler
        //All the business logic to execute. Return a response
        public class Handler : IRequestHandler<GetTodoByIdQuery, Response>
        {
            private readonly Repository _repository;
            public Handler(Repository repository)
            {
                _repository = repository;
            }
            public async Task<Response> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
            {
                //all logic goes here
                var todo = await _repository.Todos.FirstOrDefaultAsync()(x => x.Id == request.Id);

                return todo == null ? null : new Response { Id = todo.Id, Name = todo.Name, Completed = todo.Completed };
            }
        }

        //Response
        //The response to be returned
        public record Response : CqrsResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Completed { get; set; }
        }


    }
}
