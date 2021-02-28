using Librarian.Data.Repo.Abstract;
using Librarian.Data.Unit.Abstract;
using System;
using System.Data.Entity;

namespace Librarian.Data.Unit.Impl
{
    public class UnitOfWork : IUnitOfWork<int>
    {
        protected DbContext _context;

        public IBookRepository<int> BookRepository { get; }

        public IReaderRepository<int> ReaderRepository { get; }

        public IAuthorRepository<int> AuthorRepository { get; } 

        public IRecordRepository<int> RecordRepository { get; }

        public IGenreRepository<int> GenreRepository { get; }

        private bool _isDisposed = false;

        public UnitOfWork(DbContext context, IBookRepository<int> bookRepo, IReaderRepository<int> readerRepo, 
                 IAuthorRepository<int> authorRepo, IRecordRepository<int> recordRepo, IGenreRepository<int> genreRepo)
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
