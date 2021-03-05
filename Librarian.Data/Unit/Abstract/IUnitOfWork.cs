using Librarian.Data.Repo.Abstract;
using System;

namespace Librarian.Data.Unit.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        IReaderRepository ReaderRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IRecordRepository RecordRepository { get; }
        IGenreRepository GenreRepository { get; }

        void Save();
    }
}
