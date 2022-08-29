using System;

namespace Politica.Domain
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Habit { get; set; }
        public int HabitId { get; set; }
        public Guid? InvitedId { get; set; }
        public DateTime? NickChangeDate { get; set; }
        public virtual Fraction Association { get; set; }
        public bool IsDeleted { get; set; }
    }
}
