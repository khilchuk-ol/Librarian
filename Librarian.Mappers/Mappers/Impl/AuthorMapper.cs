using Librarian.Domain.Models.Core;
using Librarian.Gui.Models;
using Librarian.Mappers.Abstract;

namespace Librarian.Mappers.Impl
{
    public class AuthorMapper : IAuthorMapper
    {
        public AuthorModel Map(Author from) =>
            new AuthorModel()
            {
                Id = from.Id,
                Name = from.Name,
                Surname = from.Surname,
                Parentname = from.Parentname
            };

        public Author Map(AuthorModel from) =>
            new Author()
            {
                Id = from.Id,
                Name = from.Name,
                Surname = from.Surname,
                Parentname = from.Parentname
            };
    }
}
