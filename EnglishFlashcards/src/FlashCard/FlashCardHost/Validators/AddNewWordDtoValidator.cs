using FluentValidation;

namespace FlashCard.Host.Validators
{
    public class AddNewWordDtoValidator : AbstractValidator<AddNewWordDto>
    {
        public AddNewWordDtoValidator()
        {
            RuleFor(x => x.Value).NotEmpty().WithMessage("The Value can`t be empty.");
            RuleFor(x => x.TranslateValue).NotEmpty().WithMessage("The TranslateValue can`t be empty.");
        }
    }
}
