using FluentValidation;

namespace FlashCard.Host.Validators
{
    public class UpdateWordDtoValidator : AbstractValidator<UpdateWordDto>
    {
        public UpdateWordDtoValidator()
        {
            RuleFor(x  => x.Id).NotEmpty().WithMessage("The Id can`t be empty."); ;
            RuleFor(x => x.Value).NotEmpty().WithMessage("The Value can`t be empty."); ;
            RuleFor(x => x.TranslateValue).NotEmpty().WithMessage("The TranslateValue can`t be empty."); ;
        }
    }
}
