﻿using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Application.Fractions.Commands.UpdateFraction;
using Politica.Application.Players.Commands.UpdatePlayer;
using Politica.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace Politica.WebApi.DataTransferObject.PlayerDto
{
    public class UpdateFractionDto : IMapWith<UpdatePlayerCommand>
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
            profile.CreateMap<UpdateFractionDto, UpdateFractionCommand>()
                .ForMember(fractionCommand => fractionCommand.Id,
                    opt => opt.MapFrom(fractionDto => fractionDto.Id))
                .ForMember(fractionCommand => fractionCommand.Title,
                    opt => opt.MapFrom(fractionDto => fractionDto.Title))
                .ForMember(fractionCommand => fractionCommand.Description,
                    opt => opt.MapFrom(fractionDto => fractionDto.Description))
                .ForMember(fractionCommand => fractionCommand.CoordinateX,
                    opt => opt.MapFrom(fractionDto => fractionDto.CoordinateX))
                .ForMember(fractionCommand => fractionCommand.CoordinateZ,
                    opt => opt.MapFrom(fractionDto => fractionDto.CoordinateZ))
                .ForMember(fractionCommand => fractionCommand.OwnerId,
                    opt => opt.MapFrom(fractionDto => fractionDto.OwnerId));
        }
    }
}
