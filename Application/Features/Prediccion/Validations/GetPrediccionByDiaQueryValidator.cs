using Application.Features.Prediccion.Queries;
using FluentValidation;

namespace Application.Features.Clima.Validations
{
    class GetPrediccionByDiaQueryValidator : AbstractValidator<GetPrediccionByDiaQuery>
    {
        public GetPrediccionByDiaQueryValidator()
        {
            int minimo = 0;
            int maximo = 365 * 10;

            this.RuleFor(query => query.Dia)
                .InclusiveBetween(minimo, maximo)
                    .WithMessage($"El día debe estar entre {minimo} y {maximo}");
        }
    }
}
