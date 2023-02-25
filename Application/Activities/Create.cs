using Application.BaseGetData.UniteOfWork;
using Domain.Entity.Active;
using MediatR;
using Persistance.Context;

namespace Application.Activities
{
    public class Create
    {

        public class command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<command>
        {
            private readonly DataContext database;
            private readonly IUniteOfWork uniteOfWork;

            public Handler(DataContext database, IUniteOfWork uniteOfWork)
            {
                this.database = database;
                this.uniteOfWork = uniteOfWork;
            }
            public async Task<Unit> Handle(command request, CancellationToken cancellationToken)
            {
                database.activities.Add(request.Activity);
                await uniteOfWork.SaveChangesAsync();

                return Unit.Value;

            }
        }
    }
}
