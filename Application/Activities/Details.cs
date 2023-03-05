using Application.Core.HandleResponseAndRequest;
using Domain.Entity.Active;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistance.Context;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Result<Activity>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
               _dataContext = dataContext;
            }
            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<Activity>.Success(await _dataContext.activities.FindAsync(request.Id));
            }
        }
    }
}
