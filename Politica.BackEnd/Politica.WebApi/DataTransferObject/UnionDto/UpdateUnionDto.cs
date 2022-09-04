using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Application.Unions.Commands.UpdateUnion;
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
        public string Coordinates { get; set; }
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
                .ForMember(unionCommand => unionCommand.Coordinates,
                    opt => opt.MapFrom(unionDto => unionDto.Coordinates))
                .ForMember(unionCommand => unionCommand.OwnerId,
                    opt => opt.MapFrom(unionDto => unionDto.OwnerId));
        }
    }
}
