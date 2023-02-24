using Application.BaseGetData.UniteOfWork;
using MediatR;
using Persistance.Context;

namespace Application.Activities
{
    public class Delete
    {
        public class Command:IRequest
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext dataContext;
            private readonly IUniteOfWork uniteOfWork;

            public Handler(DataContext dataContext,IUniteOfWork uniteOfWork)
            {
                this.dataContext = dataContext;
                this.uniteOfWork = uniteOfWork;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activeDb=await dataContext.activities.FindAsync(request.Id) ;
                if (activeDb != null)
                {
                  dataContext.Remove(activeDb); 
                  await uniteOfWork.SaveChangesAsync();
                }
                return Unit.Value;

            }
        }
    }
}
