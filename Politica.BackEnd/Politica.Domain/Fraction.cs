using System;
using System.Collections.Generic;

namespace Politica.Domain
{
    public class Fraction
    {
        Guid OwnerId { get; set; }
        Guid Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string Coordinates { get; set; }
        IEnumerable<Player> ListPlayers { get; set; }
    }
}
