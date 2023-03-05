using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Domain.Entity.Active;
using Application.Core.HandleResponseAndRequest;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<Activity>>>{ }

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
             private readonly DataContext _dataContext;

            public Handler( DataContext dataContext)
            {
                 _dataContext = dataContext;
            }
            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var res= await _dataContext.activities.ToListAsync();
                return Result<List<Activity>>.Success(res); 
            }
        }

    }
}
