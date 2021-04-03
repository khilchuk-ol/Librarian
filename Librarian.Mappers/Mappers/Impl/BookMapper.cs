using Librarian.Domain.Models.Core;
using Librarian.Gui.Models;
using Librarian.Mappers.Abstract;
using System;
using System.Linq;

namespace Librarian.Mappers.Impl
{
    public class BookMapper : IBookMapper
    {
        public BookModel Map(Book from) =>
            new BookModel()
            {
                Id = from.Id,
                Title = from.Title,
                ReleaseDate = from.ReleaseDate,
                Number = from.Number,
                PageCount = from.PageCount,
                IsBorrowed = from.IsBorrowed,
                GenresStr = from.Genres == null ? null : string.Join(", ", from.Genres.Select(g => g.Name)),
                AuthorsStr = from.Authors == null ? null : string.Join(" ", from.Authors.Select(a => a.Fullname))
            };

        public Book Map(BookModel from) =>
            new Book()
            {
                Id = from.Id,
                Title = from.Title,
                ReleaseDate = from.ReleaseDate,
                Number = from.Number,
                PageCount = from.PageCount,
                IsBorrowed = from.IsBorrowed
            };

        public void Map(BookModel from, Book to)
        {
            if (to.Id != from.Id)
                throw new ArgumentException("Cannot map. Object are not related");
            to.Title = from.Title;
            to.IsBorrowed = from.IsBorrowed;
            to.ReleaseDate = from.ReleaseDate;
            to.PageCount = from.PageCount;
            to.Number = from.Number;
        }
    }
}
