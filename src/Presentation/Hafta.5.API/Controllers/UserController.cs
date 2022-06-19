using Hafta._5.Application.Features.Commands.User.CreateUser;
using Hafta._5.Application.Features.Queries.User.GetUser;
using Hafta._5.Application.Interfaces.EventServices;
using Hafta._5.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Hafta._5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        private ICreateUserEvent _createUserEvent;
        public UserController(IMediator mediator, ICreateUserEvent createUserEvent)
        {
            _mediator = mediator;
            _createUserEvent = createUserEvent;
        }

        [HttpGet]//Kullanıcıları gerekli filtreleme, arama ve sayfalama özelliklerine göre getiren endpoint.
        public async Task<IActionResult> GetUser([FromQuery] GetUserQueryRequest getUserQueryRequest)
        {
            GetUserQueryResponse getUserQueryResponse = await _mediator.Send(getUserQueryRequest);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(getUserQueryResponse.MetaPageInfo));
            return Ok(getUserQueryResponse.AppUsers);
        }

        [HttpPost]//Kullanıcı oluşturup gerekli eventi oluşturan endpoint.
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse createUserCommandResponse = await _mediator.Send(createUserCommandRequest);
            _createUserEvent.SendEvent(createUserCommandRequest.UserName);
            return Ok(createUserCommandResponse);

        }

    }
}
