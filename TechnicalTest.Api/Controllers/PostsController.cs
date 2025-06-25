using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Core.Posts.ReadModels;
using TechnicalTest.UseCases.Posts;
using TechnicalTest.UseCases.Posts.Create;
using TechnicalTest.UseCases.Posts.Get;

namespace TechnicalTest.Api.Controllers
{
    [ApiController]
    [Route("api/post")]
    public sealed class PostsController(IMediator _mediator) : Controller
    {

        // GET api/post/5
        /// <summary>Get post by id</summary>
        /// <param name="id">Id of post to return</param>
        /// <response code="200">Succesful operation </response>
        /// <response code="404">No post matching the id</response>
        [ProducesResponseType(typeof(PostReadModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PostWithAuthorReadModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, [FromQuery] bool withAuthor, CancellationToken cancellationToken)
            => withAuthor ? Ok(await _mediator.Send(new GetPostWithAuthorQuery(id), cancellationToken))
                : Ok(await _mediator.Send(new GetPostQuery(id), cancellationToken));

        // POST api/post/
        /// <summary>Create a post</summary>
        /// <response code="200">Succesful operation </response>
        /// <response code="400">Bad Request operation </response>
        /// <response code="404">No Author matching the authorId</response>
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostCommand request, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(request, cancellationToken));
    }
}
