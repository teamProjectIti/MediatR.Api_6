using Application.BaseGetData.UniteOfWork;
using Application.Core.HandleResponseAndRequest;
using Domain.Entity.Active;
using FluentValidation;
using MediatR;
using Persistance.Context;

namespace Application.Activities
{
    public class Edit
    {
        public class command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }

        public class commandValidatoe : AbstractValidator<Activity>
        {
            public commandValidatoe()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }
        public class Handler : IRequestHandler<command,Result<Unit>>
        {
            private readonly DataContext dataContext;
            private readonly IUniteOfWork uniteOfWork;

            public Handler(DataContext dataContext,IUniteOfWork uniteOfWork)
            {
                this.dataContext = dataContext;
                this.uniteOfWork = uniteOfWork;
            }
            public async Task<Result<Unit>> Handle(command request, CancellationToken cancellationToken)
            {
                var activityDb = await dataContext.activities.FindAsync(request.Activity.Id);
                if (activityDb != null)
                    activityDb.Title = request.Activity.Title ?? activityDb.Title;

                //dataContext.activities.Update(request.Activity);
               if(await uniteOfWork.SaveChangesAsync()>1) return Result<Unit>.Failure("Failed Update Activity");

                return  Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
