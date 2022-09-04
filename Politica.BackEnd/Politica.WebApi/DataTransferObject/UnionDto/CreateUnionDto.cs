using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Application.Unions.Commands.CreateUnion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Politica.WebApi.DataTransferObject.UnionDto
{
    public class CreateUnionDto : IMapWith<CreateUnionCommand>
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Coordinates { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public IEnumerable<Guid> Fractions { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUnionDto, CreateUnionCommand>()
                .ForMember(unionCommand => unionCommand.Title,
                    opt => opt.MapFrom(unionDto => unionDto.Title))
                .ForMember(unionCommand => unionCommand.Description,
                    opt => opt.MapFrom(unionDto => unionDto.Description))
                .ForMember(unionCommand => unionCommand.Coordinates,
                    opt => opt.MapFrom(unionDto => unionDto.Coordinates))
                .ForMember(unionCommand => unionCommand.OwnerId,
                    opt => opt.MapFrom(unionDto => unionDto.OwnerId))
                .ForMember(unionCommand => unionCommand.Fractions,
                    opt => opt.MapFrom(unionDto => unionDto.Fractions));
        }
    }
}
