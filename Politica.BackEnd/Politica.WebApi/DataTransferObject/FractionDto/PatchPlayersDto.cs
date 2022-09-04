using AutoMapper;
using Politica.Application.Fractions.Commands.UpdatePlayers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Politica.WebApi.DataTransferObject.FractionDto
{
    public class PatchPlayersDto
    {
        [Required]
        public Guid Id { get; set; }
        public IEnumerable<Guid> Players { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatchPlayersDto, UpdatePlayersCommand>()
                .ForMember(fractionCommand => fractionCommand.Id,
                    opt => opt.MapFrom(fractionDto => fractionDto.Id))
                .ForMember(fractionCommand => fractionCommand.Players,
                    opt => opt.MapFrom(fractionDto => fractionDto.Players));
        }
    }
}
