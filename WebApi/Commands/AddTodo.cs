using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Database;
using WebApi.Validations;
using static WebApi.Dtos;

namespace WebApi.Commands
{
    public static class AddTodo
    {
        //Command or Query Class
        public record AddTodoCommand(string Name) : IRequest<AddTodoResponse>;

        //Validator Class
        //Domain based business rules will go here and not api level validatioin 
        public class Validator : IValidationHandler<AddTodoCommand>
        {
            private readonly Repository repository;

            public Validator(Repository repository) => this.repository = repository;

            public async Task<ValidationResult> Validate(AddTodoCommand request)
            {
                if (repository.Todos.Any(x => x.Name.Equals(request.Name, System.StringComparison.OrdinalIgnoreCase)))
                    return ValidationResult.Fail("Todo already exist");

                return ValidationResult.Success;
            }
        }

        //Handler
        public class Handler : IRequestHandler<AddTodoCommand, AddTodoResponse>
        {
            private readonly Repository repository;

            public Handler(Repository repository)
            {
                this.repository = repository;
            }


            public async Task<AddTodoResponse> Handle(AddTodoCommand request, CancellationToken cancellationToken)
            {
                repository.Todos.Add(new Domain.Todo { Id = 10, Name = request.Name });
                return new AddTodoResponse { Id = 10 } ;
            }
        }


        //Response for add to do 
        public record AddTodoResponse : CqrsResponse
        {
            public int Id { get; set; }
        }

    }
}
