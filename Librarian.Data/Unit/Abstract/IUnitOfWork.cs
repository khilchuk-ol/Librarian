using Librarian.Data.Repo.Abstract;
using System;

namespace Librarian.Data.Unit.Abstract
{
    public interface IUnitOfWork<TIdentity> : IDisposable
    {
        IBookRepository<TIdentity> BookRepository { get; }
        IReaderRepository<TIdentity> ReaderRepository { get; }
        IAuthorRepository<TIdentity> AuthorRepository { get; }
        IRecordRepository<TIdentity> RecordRepository { get; }
        IGenreRepository<TIdentity> GenreRepository { get; }

        void Save();
    }
}
