using AutoMapper;
using Politica.Application.Common.Mappings;
using Politica.Domain;
using System;
using System.Collections.Generic;

namespace Politica.Application.Unions.Queries.GetUnionDetails
{
    public class UnionDetailsVm : IMapWith<Union>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public virtual Guid OwnerId { get; set; }
        public virtual IEnumerable<Fraction> Fractions { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Union, UnionDetailsVm>()
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
                .ForMember(t => t.Fractions,
                opt => opt.MapFrom(eve => eve.Fractions))
                .ForMember(t => t.IsDeleted,
                opt => opt.MapFrom(eve => eve.IsDeleted));
        }
    }
}
