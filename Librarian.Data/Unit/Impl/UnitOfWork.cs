using Librarian.Data.Repo.Abstract;
using Librarian.Data.Unit.Abstract;
using System;
using System.Data.Entity;

namespace Librarian.Data.Unit.Impl
{
    public class UnitOfWork<TIdentity> : IUnitOfWork<TIdentity>
    {
        protected DbContext _context;

        public IBookRepository<TIdentity> BookRepository { get; }

        public IReaderRepository<TIdentity> ReaderRepository { get; }

        public IAuthorRepository<TIdentity> AuthorRepository { get; } 

        public IRecordRepository<TIdentity> RecordRepository { get; }

        public IGenreRepository<TIdentity> GenreRepository { get; }

        private bool _isDisposed = false;

        public UnitOfWork(DbContext context, IBookRepository<TIdentity> bookRepo, IReaderRepository<TIdentity> readerRepo, 
                 IAuthorRepository<TIdentity> authorRepo, IRecordRepository<TIdentity> recordRepo, IGenreRepository<TIdentity> genreRepo)
        {
            _context = context;

            /*BookRepository = new BookRepository(_context);
            ReaderRepository = new ReaderRepository(_context);
            AuthorRepository = new AuthorRepository(_context);
            GenreRepository = new GenreRepository(_context);
            RecordRepository = new RecordRepository(_context);*/

            BookRepository = bookRepo;
            ReaderRepository = readerRepo;
            AuthorRepository = authorRepo;
            GenreRepository = genreRepo;
            RecordRepository = recordRepo;
        }

        public virtual void Dispose(bool disposing)
        {
            if(!_isDisposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
