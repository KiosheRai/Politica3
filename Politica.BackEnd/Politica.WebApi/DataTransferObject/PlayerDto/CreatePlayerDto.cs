using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Application.Players.Commands.CreatePlayer;
using System;
using System.ComponentModel.DataAnnotations;

namespace Politica.WebApi.DataTransferObject
{
    public class CreatePlayerDto : IMapWith<CreatePlayerCommand>
    {
        [Required]
        public string Name { get; set; }
        public string Habit { get; set; }
        public int HabitId { get; set; }
        public Guid? InvitedId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePlayerDto, CreatePlayerCommand>()
                .ForMember(playerCommand => playerCommand.Name,
                    opt => opt.MapFrom(eventDto => eventDto.Name))
                .ForMember(playerCommand => playerCommand.Habit,
                    opt => opt.MapFrom(eventDto => eventDto.Habit))
                .ForMember(playerCommand => playerCommand.HabitId,
                    opt => opt.MapFrom(eventDto => eventDto.HabitId))
                .ForMember(playerCommand => playerCommand.InvitedId,
                    opt => opt.MapFrom(eventDto => eventDto.InvitedId));
        }
    }
}
