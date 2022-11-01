using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Application.Unions.Commands.UpdateUnion;
using Politica.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace Politica.WebApi.DataTransferObject.UnionDto
{
    public class UpdateUnionDto : IMapWith<UpdateUnionCommand>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double CoordinateX { get; set; }
        [Required]
        public double CoordinateZ { get; set; }
        [Required]
        public Guid OwnerId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUnionDto, UpdateUnionCommand>()
                .ForMember(unionCommand => unionCommand.Id,
                    opt => opt.MapFrom(unionDto => unionDto.Id))
                .ForMember(unionCommand => unionCommand.Title,
                    opt => opt.MapFrom(unionDto => unionDto.Title))
                .ForMember(unionCommand => unionCommand.Description,
                    opt => opt.MapFrom(unionDto => unionDto.Description))
                .ForMember(unionCommand => unionCommand.CoordinateX,
                    opt => opt.MapFrom(unionDto => unionDto.CoordinateX))
                .ForMember(unionCommand => unionCommand.CoordinateZ,
                    opt => opt.MapFrom(unionDto => unionDto.CoordinateZ))
                .ForMember(unionCommand => unionCommand.OwnerId,
                    opt => opt.MapFrom(unionDto => unionDto.OwnerId));
        }
    }
}
