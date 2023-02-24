﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Domain.Entity.Active;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
             private readonly DataContext _dataContext;

            public Handler( DataContext dataContext)
            {
                 _dataContext = dataContext;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.activities.ToListAsync();
            }
        }

    }
}
