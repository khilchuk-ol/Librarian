using Librarian.Domain.Models.Core;
using Librarian.Gui.Models;
using Librarian.Mappers.Abstract;

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
    }
}
