using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Domain;
using System;

namespace Politica.Application.Players.Queries.GetPlayerDetails
{
    public class PlayerDetailsVm : IMapWith<Player>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Habit { get; set; }
        public int HabitId { get; set; }
        public Guid? InvitedId { get; set; }
        public DateTime? NickChangeDate { get; set; }
        public virtual Fraction Association { get; set; }
        public bool IsDeleted { get; set; }
        public object Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Player, PlayerDetailsVm>()
                .ForMember(t => t.Id,
                opt => opt.MapFrom(eve => eve.Id))
                .ForMember(t => t.Name,
                opt => opt.MapFrom(eve => eve.Name))
                .ForMember(t => t.Habit,
                opt => opt.MapFrom(eve => eve.Habit))
                .ForMember(t => t.HabitId,
                opt => opt.MapFrom(eve => eve.HabitId))
                .ForMember(t => t.InvitedId,
                opt => opt.MapFrom(eve => eve.InvitedId))
                .ForMember(t => t.NickChangeDate,
                opt => opt.MapFrom(eve => eve.NickChangeDate))
                .ForMember(t => t.Association,
                opt => opt.MapFrom(eve => eve.Association))
                .ForMember(t => t.IsDeleted,
                opt => opt.MapFrom(eve => eve.IsDeleted));
        }
    }
}
