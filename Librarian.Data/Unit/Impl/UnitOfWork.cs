using Librarian.Data.Repo.Abstract;
using Librarian.Data.Unit.Abstract;
using System;
using System.Data.Entity;

namespace Librarian.Data.Unit.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext _context;

        public IBookRepository BookRepository { get; }
        public IReaderRepository ReaderRepository { get; }
        public IAuthorRepository AuthorRepository { get; } 
        public IRecordRepository RecordRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IGenreBookRepository GenreBookRepository { get; }
        public IBookAuthorRepository BookAuthorRepository { get; }

        private bool _isDisposed = false;

        public UnitOfWork(DbContext context, IBookRepository bookRepo, IReaderRepository readerRepo, IAuthorRepository authorRepo, 
            IRecordRepository recordRepo, IGenreRepository genreRepo, IBookAuthorRepository bookAuthorRepo, IGenreBookRepository genreBookRepo)
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
            BookAuthorRepository = bookAuthorRepo;
            GenreBookRepository = genreBookRepo;
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
