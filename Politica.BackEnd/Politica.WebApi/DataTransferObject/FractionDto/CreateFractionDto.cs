using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Application.Fractions.Commands.CreateFraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Politica.WebApi.DataTransferObject.FractionDto
{
    public class CreateFractionDto : IMapWith<CreateFractionCommand>
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Coordinates { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public IEnumerable<Guid> Players { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFractionDto, CreateFractionCommand>()
                .ForMember(fractionCommand => fractionCommand.Title,
                    opt => opt.MapFrom(fractionDto => fractionDto.Title))
                .ForMember(fractionCommand => fractionCommand.Description,
                    opt => opt.MapFrom(fractionDto => fractionDto.Description))
                .ForMember(fractionCommand => fractionCommand.Coordinates,
                    opt => opt.MapFrom(fractionDto => fractionDto.Coordinates))
                .ForMember(fractionCommand => fractionCommand.OwnerId,
                    opt => opt.MapFrom(fractionDto => fractionDto.OwnerId))
                .ForMember(fractionCommand => fractionCommand.Players,
                        opt => opt.MapFrom(fractionDto => fractionDto.Players));
        }
    }
}
