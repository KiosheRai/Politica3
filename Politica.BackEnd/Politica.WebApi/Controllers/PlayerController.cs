using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Politica.Application.Players.Commands.CreatePlayer;
using Politica.Application.Players.Commands.DeletePlayer;
using Politica.Application.Players.Commands.UpdateFractionPlayer;
using Politica.Application.Players.Commands.UpdatePlayer;
using Politica.Application.Players.Queries.GetPlayerDetails;
using Politica.Application.Players.Queries.GetPlayerList;
using Politica.WebApi.DataTransferObject;
using Politica.WebApi.DataTransferObject.PlayerDto;
using System;
using System.Threading.Tasks;

namespace Politica.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : BaseController
    {
        private readonly IMapper _mapper;

        public PlayerController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PlayerListVm>> GetAll()
        {
            var query = new GetPlayerListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PlayerDetailsVm>> Get(Guid id)
        {
            var query = new GetPlayerDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Create([FromBody] CreatePlayerDto createPlayerDto)
        {
            var command = _mapper.Map<CreatePlayerCommand>(createPlayerDto);
            //command.UserId = UserId;
            var playerId = await Mediator.Send(command);
            return Ok(playerId);
        }

        [HttpPut]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(409)]
        public async Task<ActionResult> Update([FromBody] UpdatePlayerDto updatePlayerDto)
        {
            var command = _mapper.Map<UpdatePlayerCommand>(updatePlayerDto);
            //command.Id = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPatch]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> UpdateAssociation([FromBody] PatchPlayerAssociationDto patchPlayerAssociationDto)
        {
            var command = _mapper.Map<UpdateFractionPlayerCommand>(patchPlayerAssociationDto);
            //command.Id = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var commnad = new DeletePlayerCommand
            {
                UserId = id
            };
            await Mediator.Send(commnad);
            return NoContent();
        }

        
    }
}
