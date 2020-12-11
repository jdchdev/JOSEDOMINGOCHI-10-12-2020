using Bertoni.Examen.Domain;
using Bertoni_Examen.Infrastructure.NetWork;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bertoni.Examen.Application.Albums
{
    public class AlbumHandler
    {
        public class RequestAlbums : IRequest<List<Album>> { }

        public class Handler : IRequestHandler<RequestAlbums, List<Album>>
        {
            private readonly IClientWrapper _clientWrapper;
            private readonly IConfiguration _configuration;
            public Handler(IClientWrapper clienWrapper, IConfiguration configuration)
            {
                _clientWrapper = clienWrapper;
                _configuration = configuration;
            }
            public async Task<List<Album>> Handle(RequestAlbums request, CancellationToken cancellationToken)
            {
               return await _clientWrapper.GetAsync<List<Album>>(_configuration.GetSection("Urls:Albums").Value);
            }
        }
    }
}
