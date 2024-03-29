﻿using System;
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
        public double CoordinateX { get; set; }
        public double CoordinateZ { get; set; }
        public virtual Guid OwnerId { get; set; }
        public virtual IEnumerable<Player> Players { get; set; }
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
                .ForMember(t => t.CoordinateX,
                opt => opt.MapFrom(eve => eve.CoordinateX))
                .ForMember(t => t.CoordinateZ,
                opt => opt.MapFrom(eve => eve.CoordinateZ))
                .ForMember(t => t.OwnerId,
                opt => opt.MapFrom(eve => eve.OwnerId))
                .ForMember(t => t.Players,
                opt => opt.MapFrom(eve => eve.Players))
                .ForMember(t => t.Association,
                opt => opt.MapFrom(eve => eve.Association))
                .ForMember(t => t.IsDeleted,
                opt => opt.MapFrom(eve => eve.IsDeleted));
        }
    }
}
