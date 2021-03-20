using Librarian.Domain.Services.Abstract;
using Librarian.Gui.Models;
using Librarian.Gui.Services.Abstract;
using Librarian.Mappers.Abstract;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarian.Gui.Services.Impl
{
    public class BookModelService : IBookModelService
    {
        private IBookMapper _mapper;
        private IBookService _service;

        public BookModelService(IBookMapper mapper, IBookService service)
        {
            if (service == null || mapper == null)
                throw new ArgumentNullException("Cannot pass null as argument for BookModelService constructor");
            _mapper = mapper;
            _service = service;
        }

        public ObservableCollection<BookModel> FindBooksByAuthor(int authorId)
        {
            var res = _service.FindBooksByAuthor(authorId);
            return new ObservableCollection<BookModel>(res.Select(b => _mapper.Map(b)));
        }

        public ObservableCollection<BookModel> FindBooksByTitle(string title)
        {
            var res = _service.FindBooksByTitle(title);
            return new ObservableCollection<BookModel>(res.Select(b => _mapper.Map(b)));
        }

        public ObservableCollection<BookModel> GetBooks()
        {
            var res = _service.GetBooks();
            return new ObservableCollection<BookModel>(res.Select(b => _mapper.Map(b)));
        }

        public BookModel GetBookWithInfo(int id) =>
            _mapper.Map(_service.GetBookWithInfo(id));
    }
}
