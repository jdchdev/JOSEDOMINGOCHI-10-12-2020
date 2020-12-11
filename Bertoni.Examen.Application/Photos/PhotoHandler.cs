using Bertoni.Examen.Domain;
using Bertoni_Examen.Infrastructure.NetWork;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bertoni.Examen.Application.Photos
{
    public class PhotoHandler
    {
        public class PhotoRequest : IRequest<List<Photo>>
        {
            public int AlbumId { get; set; }
        }

        public class Handler : IRequestHandler<PhotoRequest, List<Photo>>
        {
            private readonly IClientWrapper _clientWrapper;
            private readonly IConfiguration _configuration;
            public Handler(IClientWrapper clienWrapper, IConfiguration configuration)
            {
                _clientWrapper = clienWrapper;
                _configuration = configuration;
            }
            public async Task<List<Photo>> Handle(PhotoRequest request, CancellationToken cancellationToken)
            {
                return await _clientWrapper.GetAsync<List<Photo>>(string.Format(_configuration.GetSection("Urls:Photos").Value, request.AlbumId));
            }
        }
    }
}
