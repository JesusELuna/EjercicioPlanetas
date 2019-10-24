using Application.Features.Prediction.Queries;
using FluentValidation;

namespace Application.Features.Prediction.Validations
{
    class GetPredictionByDayQueryValidator : AbstractValidator<GetPredictionByDayQuery>
    {
        public GetPredictionByDayQueryValidator()
        {
            int minimo = 0;
            int maximo = 365 * 10;

            this.RuleFor(query => query.Day)
                .InclusiveBetween(minimo, maximo)
                    .WithMessage($"El día debe estar entre {minimo} y {maximo}");
        }
    }
}
