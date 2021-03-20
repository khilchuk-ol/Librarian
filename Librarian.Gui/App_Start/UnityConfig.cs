using Librarian.Data.Data;
using Librarian.Data.Repo.Abstract;
using Librarian.Data.Repo.Impl;
using Librarian.Data.Unit.Abstract;
using Librarian.Data.Unit.Impl;
using Librarian.Domain.Factories.Abstract;
using Librarian.Domain.Factories.Impl;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Services.Abstract;
using Librarian.Domain.Services.Impl;
using Librarian.Domain.Strategies.TypesEnum;
using Librarian.Gui.Services.Abstract;
using Librarian.Gui.Services.Impl;
using Librarian.Mappers.Abstract;
using Librarian.Mappers.Impl;
using System;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;

namespace Librarian.Gui.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, LibrarianContext>(new SingletonLifetimeManager());

            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IRecordRepository, RecordRepository>();
            container.RegisterType<IReaderRepository, ReaderRepository>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
            container.RegisterType<IGenreRepository, GenreRepository>();
            container.RegisterType<IGenreBookRepository, GenreBookRepository>();
            container.RegisterType<IBookAuthorRepository, BookAuthorRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<FindStrategyFactory<Book, FindBooksType>, FindBooksStrategyFactory>();
            container.RegisterType<FindStrategyFactory<Reader, FindReadersType>, FindReadersStrategyFactory>();
            container.RegisterType<FindStrategyFactory<Author, FindAuthorsType>, FindAuthorsStrategyFactory>();
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<IReaderService, ReaderService>();
            container.RegisterType<IRecordService, RecordService>();
            container.RegisterType<IAuthorService, AuthorService>();
            container.RegisterType<IBookMapper, BookMapper>();
            container.RegisterType<IRecordMapper, RecordMapper>();
            container.RegisterType<IReaderMapper, ReaderMapper>();
            container.RegisterType<IAuthorMapper, AuthorMapper>();
            container.RegisterType<IGenreMapper, GenreMapper>();
            container.RegisterType<IBookModelService, BookModelService>();
            container.RegisterType<IAuthorModelService, AuthorModelService>();
            container.RegisterType<IReaderModelService, ReaderModelService>();
            container.RegisterType<IRecordModelService, RecordModelService>();
        }
    }
}
