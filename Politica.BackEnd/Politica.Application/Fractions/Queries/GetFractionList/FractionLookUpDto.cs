using System;
using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Domain;

namespace Politica.Application.Fractions.Queries.GetFractionList
{
    public class FractionLookUpDto : IMapWith<Fraction>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Coordinates { get; set; }
        public virtual Guid OwnerId { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fraction, FractionLookUpDto>()
                .ForMember(t => t.Id,
                opt => opt.MapFrom(eve => eve.Id))
                .ForMember(t => t.Title,
                opt => opt.MapFrom(eve => eve.Title))
                .ForMember(t => t.Coordinates,
                opt => opt.MapFrom(eve => eve.Coordinates))
                .ForMember(t => t.OwnerId,
                opt => opt.MapFrom(eve => eve.OwnerId))
                .ForMember(t => t.IsDeleted,
                opt => opt.MapFrom(eve => eve.IsDeleted));
        }
    }
}
