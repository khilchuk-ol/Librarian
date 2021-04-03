using Librarian.Domain.Models.Core;
using Librarian.Gui.Models;
using Librarian.Mappers.Abstract;
using System;

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

        public void Map(AuthorModel from, Author to)
        {
            if (to.Id != from.Id)
                throw new ArgumentException("Cannot map. Object are not related");
            to.Name = from.Name;
            to.Surname = from.Surname;
            to.Parentname = from.Parentname;
        }
    }
}
