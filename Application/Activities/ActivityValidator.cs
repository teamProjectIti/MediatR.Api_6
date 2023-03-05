using Domain.Entity.Active;
using FluentValidation;

namespace Application.Activities
{
    public class ActivityValidator:AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Describation).NotEmpty();
            RuleFor(x => x.Caregory).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Venu).NotEmpty();
        }
    }
}
