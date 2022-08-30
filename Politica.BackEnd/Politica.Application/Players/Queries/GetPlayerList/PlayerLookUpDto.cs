using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politica.Application.Players.Queries.GetPlayerList
{
    public class PlayerLookUpDto : IMapWith<Player>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Habit { get; set; }
        public int HabitId { get; set; }
        public virtual Fraction Association { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Player, PlayerLookUpDto>()
                .ForMember(t => t.Id,
                opt => opt.MapFrom(eve => eve.Id))
                .ForMember(t => t.Name,
                opt => opt.MapFrom(eve => eve.Name))
                .ForMember(t => t.Habit,
                opt => opt.MapFrom(eve => eve.Habit))
                .ForMember(t => t.HabitId,
                opt => opt.MapFrom(eve => eve.HabitId))
                .ForMember(t => t.Association,
                opt => opt.MapFrom(eve => eve.Association))
                .ForMember(t => t.IsDeleted,
                opt => opt.MapFrom(eve => eve.IsDeleted));
        }
    }
}
