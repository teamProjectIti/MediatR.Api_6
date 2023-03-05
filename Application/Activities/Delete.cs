using Application.BaseGetData.UniteOfWork;
using Application.Core.HandleResponseAndRequest;
using MediatR;
using Persistance.Context;

namespace Application.Activities
{
    public class Delete
    {
        public class Command:IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext dataContext;
            private readonly IUniteOfWork uniteOfWork;

            public Handler(DataContext dataContext,IUniteOfWork uniteOfWork)
            {
                this.dataContext = dataContext;
                this.uniteOfWork = uniteOfWork;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activeDb=await dataContext.activities.FindAsync(request.Id) ;
                if (activeDb != null)
                {
                  dataContext.Remove(activeDb); 
                  if(await uniteOfWork.SaveChangesAsync()>0) return Result<Unit>.Failure("Can Not Delete This Active");
                }
                return Result < Unit >.Success(Unit.Value);
            }
        }
    }
}
