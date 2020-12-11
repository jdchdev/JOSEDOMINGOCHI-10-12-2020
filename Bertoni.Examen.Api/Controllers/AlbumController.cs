using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bertoni.Examen.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Bertoni.Examen.Application.Albums.AlbumHandler;
using static Bertoni.Examen.Application.Comments.CommentsHandler;
using static Bertoni.Examen.Application.Photos.PhotoHandler;

namespace Bertoni.Examen.Api.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IMediator _mediator;
        public AlbumController(IMediator mediator) => _mediator = mediator;

        [Route("api/Albums")]
        public async Task<ActionResult<List<Album>>> Index()
        {
            return await _mediator.Send(new RequestAlbums());
        }

        [Route("api/PhotoAlbums/{id}")]
        public async Task<ActionResult<List<Photo>>> Index(int id)
        {
            return await _mediator.Send(new PhotoRequest() {  AlbumId = id});
        }

        [Route("api/Comments/{id}")]
        public async Task<ActionResult<List<Comment>>> Comments(int id)
        {
            return await _mediator.Send(new RequestComment() { id = id });
        }
    }
}
