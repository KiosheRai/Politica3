using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Politica.Application.Fractions.Commands.CreateFraction;
using Politica.Application.Fractions.Commands.DeleteFraction;
using Politica.Application.Fractions.Commands.UpdateFraction;
using Politica.Application.Fractions.Commands.UpdatePlayers;
using Politica.Application.Fractions.Queries.GetFractionDetails;
using Politica.Application.Fractions.Queries.GetFractionList;
using Politica.WebApi.DataTransferObject.FractionDto;
using Politica.WebApi.DataTransferObject.PlayerDto;
using System;
using System.Threading.Tasks;

namespace Politica.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FractionController : BaseController
    {
        private readonly IMapper _mapper;

        public FractionController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FractionListVm>> GetAll()
        {
            var query = new GetFractionListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FractionDetailsVm>> Get(Guid id)
        {
            var query = new GetFractionDetailsQuery
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
        public async Task<ActionResult> Create([FromBody] CreateFractionDto createFractionDto)
        {
            var command = _mapper.Map<CreateFractionCommand>(createFractionDto);
            //command.UserId = UserId;
            var FractionId = await Mediator.Send(command);
            return Ok(FractionId);
        }

        [HttpPut]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateFractionDto updateFractionDto)
        {
            var command = _mapper.Map<UpdateFractionCommand>(updateFractionDto);
            //command.Id = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPatch]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> UpdateAssociation([FromBody] PatchPlayersDto patchPlayersDto)
        {
            var command = _mapper.Map<UpdatePlayersCommand>(patchPlayersDto);
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
            var commnad = new DeleteFractionCommand
            {
                Id = id
            };
            await Mediator.Send(commnad);
            return NoContent();
        }

        
    }
}
