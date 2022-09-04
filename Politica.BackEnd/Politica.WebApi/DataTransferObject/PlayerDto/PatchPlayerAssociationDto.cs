using AutoMapper;
using Politica.Application.Players.Commands.UpdateFractionPlayer;
using System;
using System.ComponentModel.DataAnnotations;

namespace Politica.WebApi.DataTransferObject.PlayerDto
{
    public class PatchPlayerAssociationDto
    {
        [Required]
        public Guid Id { get; set; }
        public Guid? Association { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PatchPlayerAssociationDto, UpdateFractionPlayerCommand>()
                .ForMember(playerCommand => playerCommand.Id,
                    opt => opt.MapFrom(playerDto => playerDto.Id))
                .ForMember(playerCommand => playerCommand.Association,
                    opt => opt.MapFrom(playerDto => playerDto.Association));
        }
    }
}
