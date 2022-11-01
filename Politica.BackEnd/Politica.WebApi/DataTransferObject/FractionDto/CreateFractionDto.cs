using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Application.Fractions.Commands.CreateFraction;
using Politica.Domain;
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
        public double CoordinateX { get; set; }
        [Required]
        public double CoordinateZ { get; set; }
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
                .ForMember(fractionCommand => fractionCommand.CoordinateX,
                    opt => opt.MapFrom(fractionDto => fractionDto.CoordinateX))
                .ForMember(fractionCommand => fractionCommand.CoordinateZ,
                    opt => opt.MapFrom(fractionDto => fractionDto.CoordinateZ))
                .ForMember(fractionCommand => fractionCommand.OwnerId,
                    opt => opt.MapFrom(fractionDto => fractionDto.OwnerId))
                .ForMember(fractionCommand => fractionCommand.Players,
                        opt => opt.MapFrom(fractionDto => fractionDto.Players));
        }
    }
}
