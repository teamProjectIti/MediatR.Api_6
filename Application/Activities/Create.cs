using Application.BaseGetData.UniteOfWork;
using Application.Core.HandleResponseAndRequest;
using Domain.Entity.Active;
using FluentValidation;
using MediatR;
using Persistance.Context;

namespace Application.Activities
{
    public class Create
    {

        public class command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }
         public class CommandValidator : AbstractValidator<command>
        {
            public CommandValidator()
            {
                 RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }
        public class Handler : IRequestHandler<command, Result<Unit>>
        {
            private readonly DataContext database;
            private readonly IUniteOfWork uniteOfWork;

            public Handler(DataContext database, IUniteOfWork uniteOfWork)
            {
                this.database = database;
                this.uniteOfWork = uniteOfWork;
            }
            public async Task<Result<Unit>> Handle(command request, CancellationToken cancellationToken)
            {
                database.activities.Add(request.Activity);
               var res= await uniteOfWork.SaveChangesAsync()>0;
                if (!res) Result<Unit>.Failure("Failed Create Activity");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
