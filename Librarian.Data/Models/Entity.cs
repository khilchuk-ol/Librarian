namespace Librarian.Data.Models
{
    public class Entity
    {
        private static int identity = 0;

        public virtual int Id { get; } = identity++;
    }
}
