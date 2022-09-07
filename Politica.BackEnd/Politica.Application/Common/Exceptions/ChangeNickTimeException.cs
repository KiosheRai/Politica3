using System;

namespace Politica.Application.Common.Exceptions
{
    public class ChangeNickTimeException : Exception
    {
        public ChangeNickTimeException(string name, object key, TimeSpan hours)
            : base($"Entity \"{name}\" ({key}) should take another \"{hours.Hours}\" hours.") { }
    }
}
