using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Application.Unions.Commands.UpdateFractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Politica.WebApi.DataTransferObject.UnionDto
{
    public class PatchFractionsDto : IMapWith<UpdateFractionsCommand>
    {
        [Required]
        public Guid Id { get; set; }
        public IEnumerable<Guid> Fractions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatchFractionsDto, UpdateFractionsCommand>()
                .ForMember(unionCommand => unionCommand.Id,
                    opt => opt.MapFrom(unionDto => unionDto.Id))
                .ForMember(unionCommand => unionCommand.Fractions,
                    opt => opt.MapFrom(unionDto => unionDto.Fractions));
        }
    }
}
