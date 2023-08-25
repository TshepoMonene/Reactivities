
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.Extensions.Logging;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.interfaces;

namespace Application.Activities
{
    public class List
    {
        public class Query:IRequest<Result<List<ActivityDto>>>{
            
        }

        public class Handler : IRequestHandler<Query, Result<List<ActivityDto>>>
        {
            private readonly DataContext context;
           
            private readonly IMapper mapper;
           private readonly IuserAccessor userAccessor;

            public Handler(DataContext context,IMapper mapper,IuserAccessor userAccessor)
            {
            this.userAccessor = userAccessor;
               this.mapper = mapper;
        
                this.context = context;
            }
            public async Task<Result<List<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                       var activities = await context.Activities
                      .ProjectTo<ActivityDto>(mapper.ConfigurationProvider, new { currentUsername = userAccessor.GetUsername() })
                      .ToListAsync(cancellationToken);

                 
                   
                return  Result<List<ActivityDto>>.Success(activities);
            }
        }
    }
}