using System;

namespace Librarian.Data.Models
{
    public sealed class Genre : Entity
    {
        public string Name { get; set; }

        public Genre(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Bad value for name");
            }

            Name = name;
        }
    }
}
