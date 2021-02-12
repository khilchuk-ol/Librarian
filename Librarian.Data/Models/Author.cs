namespace Librarian.Data.Models
{
    public sealed class Author : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; } = "";
        public string Parentname { get; set; } = "";

        public string Fullname => string.Join(" ", new[] { Name, Surname, Parentname});
    }
}
