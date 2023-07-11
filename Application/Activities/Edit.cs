using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
                public Activity Activity { get; set; }
                public class Handler:IRequestHandler<Command>
                {
                     private readonly DataContext context;
                      private readonly IMapper Mapper;
                    public Handler(DataContext context ,IMapper mapper)
                    {
                     this.Mapper = mapper;
                     this.context = context;
                        
                    }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                   var activity = await context.Activities.FindAsync(request.Activity.Id);
                   Mapper.Map(request.Activity, activity);
                   await context.SaveChangesAsync();
                   return Unit.Value;
                }
            }
        }
    }
}