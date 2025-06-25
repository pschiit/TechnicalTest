using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Core.Authors.ReadModels;
using TechnicalTest.UseCases.Authors.Create;
using TechnicalTest.UseCases.Authors.Get;

namespace TechnicalTest.Api.Controllers
{
    [ApiController]
    [Route("api/author")]
    public sealed class AuthorsController(IMediator _mediator) : Controller
    {

        // GET api/author/5
        /// <summary>Get author by id</summary>
        /// <param name="id">Id of author to return</param>
        /// <response code="200">Succesful operation </response>
        /// <response code="404">No author matching the id</response>
        [ProducesResponseType(typeof(AuthorReadModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(new GetAuthorQuery(id), cancellationToken));

        // POST api/author/
        /// <summary>Create a author</summary>
        /// <response code="200">Succesful operation </response>
        /// <response code="400">Bad Request operation </response>
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand request, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(request, cancellationToken));
    }
}
