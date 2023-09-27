namespace WebApi.Validations
{
    public class ValidationResult
    {
        public bool IsSuccessful { get; set; } = true; 
        public string Error { get; init; }


        //Validation methods
        public static ValidationResult Success => new ValidationResult();

        public static ValidationResult Fail(string error) => new ValidationResult { IsSuccessful = false, Error = error};      

    }
}