using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Politica.Application.Unions.Commands.CreateUnion;
using Politica.Application.Unions.Commands.DeleteUnion;
using Politica.Application.Unions.Commands.UpdateUnion;
using Politica.Application.Unions.Queries.GetUnionDetails;
using Politica.Application.Unions.Queries.GetUnionList;
using Politica.WebApi.DataTransferObject.UnionDto;
using System;
using System.Threading.Tasks;

namespace Politica.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UnionController : BaseController
    {
        private readonly IMapper _mapper;

        public UnionController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UnionListVm>> GetAll()
        {
            var query = new GetUnionListQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UnionDetailsVm>> Get(Guid id)
        {
            var query = new GetUnionDetailsQuery
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
        public async Task<ActionResult> Create([FromBody] CreateUnionDto createUnionDto)
        {
            var command = _mapper.Map<CreateUnionCommand>(createUnionDto);
            //command.UserId = UserId;
            var UnionId = await Mediator.Send(command);
            return Ok(UnionId);
        }

        [HttpPut]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateUnionDto updateUnionDto)
        {
            var command = _mapper.Map<UpdateUnionCommand>(updateUnionDto);
            //command.Id = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPatch]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> UpdateAssociation([FromBody] PatchFractionsDto patchFractionsDto)
        {
            var command = _mapper.Map<PatchFractionsDto>(patchFractionsDto);
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
            var commnad = new DeleteUnionCommand
            {
                Id = id
            };
            await Mediator.Send(commnad);
            return NoContent();
        }

        
    }
}
