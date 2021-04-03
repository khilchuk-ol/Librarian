using Librarian.Domain.Models.Core;
using Librarian.Gui.Models;
using Librarian.Mappers.Abstract;
using System;

namespace Librarian.Mappers.Impl
{
    public class GenreMapper : IGenreMapper
    {
        public GenreModel Map(Genre from) =>
            new GenreModel()
            {
                Id = from.Id,
                Name = from.Name
            };

        public Genre Map(GenreModel from) =>
            new Genre()
            {
                Id = from.Id,
                Name = from.Name
            };

        public void Map(GenreModel from, Genre to)
        {
            if (to.Id != from.Id)
                throw new ArgumentException("Cannot map. Object are not related");
            to.Name = from.Name;
        }
    }
}
