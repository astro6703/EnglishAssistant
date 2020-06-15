using FluentValidation;

namespace EnglishAssistant.RequestParameters.Validators
{
    public class UserRequestParametersValidator : AbstractValidator<UserRequestParameters>
    {
        public UserRequestParametersValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}