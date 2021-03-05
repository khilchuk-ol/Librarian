using Librarian.Data.Data;
using Librarian.Data.Repo.Abstract;
using Librarian.Data.Repo.Impl;
using Librarian.Data.Unit.Abstract;
using Librarian.Data.Unit.Impl;
using Librarian.Domain.Factories.Abstract;
using Librarian.Domain.Factories.Impl;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Present.Impl;
using Librarian.Domain.Services.Abstract;
using Librarian.Domain.Services.Impl;
using Librarian.Domain.Strategies.TypesEnum;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.Entity;

namespace Librarian.Data
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = CreateHostBuilder(args).Build().Services;

            var rsc = services.GetService<IReaderService>();
            var bsc = services.GetService<IBookService>();
            var asc = services.GetService<IAuthorService>();

            var present = new ConsolePresentable(bsc, rsc, asc);
            present.Show();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((_, services) =>
               {
                   services.AddSingleton<DbContext, LibrarianContext>();
                   services.AddScoped<IBookRepository, BookRepository>();
                   services.AddScoped<IReaderRepository, ReaderRepository>();
                   services.AddScoped<IAuthorRepository, AuthorRepository>();
                   services.AddScoped<IGenreRepository, GenreRepository>();
                   services.AddScoped<IRecordRepository, RecordRepository>();
                   services.AddScoped<IUnitOfWork, UnitOfWork>();
                   services.AddScoped<FindStrategyFactory<Book, FindBooksType>, FindBooksStrategyFactory>();
                   services.AddScoped<FindStrategyFactory<Reader, FindReadersType>, FindReadersStrategyFactory>();
                   services.AddScoped<FindStrategyFactory<Author, FindAuthorsType>, FindAuthorsStrategyFactory>();
                   services.AddScoped<IBookService, BookService>();
                   services.AddScoped<IReaderService, ReaderService>();
                   services.AddScoped<IAuthorService, AuthorService>();
               });     
    }
}
