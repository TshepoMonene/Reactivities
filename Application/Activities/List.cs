
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.Extensions.Logging;
using Application.Core;

namespace Application.Activities
{
    public class List
    {
        public class Query:IRequest<Result<List<Activity>>>{
            
        }

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly DataContext context;
           

            public Handler(DataContext context)
            {
        
                this.context = context;
            }
            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                       var activities = await context.Activities
                       .Include(a => a.Attendees)
                       .ThenInclude(u=> u.AppUser)
                   .ToListAsync(cancellationToken);
                   
                return  Result<List<Activity>>.Success(activities);
            }
        }
    }
}