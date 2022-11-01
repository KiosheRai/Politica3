using System;
using System.Collections.Generic;

namespace Politica.Domain
{
    public class Union
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateZ { get; set; }
        public virtual Guid OwnerId { get; set; }
        public virtual IEnumerable<Fraction> Fractions { get; set; }
        public bool IsDeleted { get; set; }
    }
}
