using FluentValidation;

namespace FlashCard.Host.Validators
{
    public class ValidationMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context, IValidatorFactory validatorFactory) 
        {
            var request = context.Request;

            if (request.Method == "POST" || request.Method == "PUT")
            {
                var model = await context.Request.ReadFromJsonAsync<WordDbModel>();

                if (model != null)
                {
                    var validator = validatorFactory.GetValidator<WordDbModel>();

                    if (validator != null)
                    {
                        var result = validator.Validate(model);

                        if (!result.IsValid)
                        {
                            context.Response.StatusCode = 400;
                            var errors = result.Errors.Select(e => e.ErrorMessage);
                            await context.Response.WriteAsJsonAsync(new { Errors = errors });
                            return;
                        }
                    }
                }
            }

            await next(context);
        }
    }
}
