using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Application.Players.Commands.UpdatePlayer;
using System;
using System.ComponentModel.DataAnnotations;

namespace Politica.WebApi.DataTransferObject.PlayerDto
{
    public class UpdatePlayerDto : IMapWith<UpdatePlayerCommand>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePlayerDto, UpdatePlayerCommand>()
                .ForMember(playerCommand => playerCommand.Id,
                    opt => opt.MapFrom(playerDto => playerDto.Id))
                .ForMember(playerCommand => playerCommand.Name,
                    opt => opt.MapFrom(playerDto => playerDto.Name));
                
        }
    }
}
