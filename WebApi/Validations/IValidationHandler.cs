using System.Threading.Tasks;

namespace WebApi.Validations
{

    public interface IValidationHandler { }

    public interface IValidationHandler<T> : IValidationHandler
    {
        Task<ValidationResult> Validate(T request);
    }
}
