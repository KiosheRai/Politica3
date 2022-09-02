using System;
using System.Collections.Generic;
using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Domain;

namespace Politica.Application.Fractions.Queries.GetFractionDetails
{
    public class FractionDetailsVm : IMapWith<Fraction>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public virtual Guid OwnerId { get; set; }
        public virtual IEnumerable<Player> ListPlayers { get; set; }
        public virtual Union Association { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fraction, FractionDetailsVm>()
                .ForMember(t => t.Id,
                opt => opt.MapFrom(eve => eve.Id))
                .ForMember(t => t.Title,
                opt => opt.MapFrom(eve => eve.Title))
                .ForMember(t => t.Description,
                opt => opt.MapFrom(eve => eve.Description))
                .ForMember(t => t.Coordinates,
                opt => opt.MapFrom(eve => eve.Coordinates))
                .ForMember(t => t.OwnerId,
                opt => opt.MapFrom(eve => eve.OwnerId))
                .ForMember(t => t.ListPlayers,
                opt => opt.MapFrom(eve => eve.ListPlayers))
                .ForMember(t => t.Association,
                opt => opt.MapFrom(eve => eve.Association))
                .ForMember(t => t.IsDeleted,
                opt => opt.MapFrom(eve => eve.IsDeleted));
        }
    }
}
