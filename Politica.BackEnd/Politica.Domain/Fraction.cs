using System;
using System.Collections.Generic;

namespace Politica.Domain
{
    public class Fraction
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public virtual Guid OwnerId { get; set; }
        public virtual IEnumerable<Player> Players { get; set; }
        public virtual Union Association { get; set; }
        public bool IsDeleted { get; set; }
    }
}
