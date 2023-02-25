using Application.BaseGetData.UniteOfWork;
using Domain.Entity.Active;
using MediatR;
using Persistance.Context;

namespace Application.Activities
{
    public class Edit
    {
        public class command : IRequest
        {
            public Activity Activity { get; set; }
        }
        public class Handler : IRequestHandler<command>
        {
            private readonly DataContext dataContext;
            private readonly IUniteOfWork uniteOfWork;

            public Handler(DataContext dataContext,IUniteOfWork uniteOfWork)
            {
                this.dataContext = dataContext;
                this.uniteOfWork = uniteOfWork;
            }
            public async Task<Unit> Handle(command request, CancellationToken cancellationToken)
            {
                var activityDb = await dataContext.activities.FindAsync(request.Activity.Id);
                if (activityDb != null)
                    activityDb.Title = request.Activity.Title ?? activityDb.Title;

                //dataContext.activities.Update(request.Activity);
               await uniteOfWork.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
