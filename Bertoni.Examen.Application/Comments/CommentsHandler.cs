using Bertoni.Examen.Domain;
using Bertoni_Examen.Infrastructure.NetWork;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bertoni.Examen.Application.Comments
{
    public class CommentsHandler
    {
        public class RequestComment : IRequest<List<Comment>> {
            public int id { get; set; }
        }

        public class Handler : IRequestHandler<RequestComment, List<Comment>>
        {
            private readonly IClientWrapper _clientWrapper;
            private readonly IConfiguration _configuration;
            public Handler(IClientWrapper clienWrapper, IConfiguration configuration)
            {
                _clientWrapper = clienWrapper;
                _configuration = configuration;
            }

            public async Task<List<Comment>> Handle(RequestComment request, CancellationToken cancellationToken)
            {
                return await _clientWrapper.GetAsync<List<Comment>>(string.Format(_configuration.GetSection("Urls:Comments").Value, request.id));
            }
        }
    }
}
