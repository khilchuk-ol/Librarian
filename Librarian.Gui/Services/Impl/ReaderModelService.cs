using Librarian.Domain.Services.Abstract;
using Librarian.Gui.Models;
using Librarian.Gui.Services.Abstract;
using Librarian.Mappers.Abstract;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarian.Gui.Services.Impl
{
    public class ReaderModelService : IReaderModelService
    {
        private IReaderMapper _mapper;
        private IReaderService _service;

        public ReaderModelService(IReaderMapper mapper, IReaderService service)
        {
            if (service == null || mapper == null)
                throw new ArgumentNullException("Cannot pass null as argument for AuthorModelService constructor");
            _mapper = mapper;
            _service = service;
        }

        public ObservableCollection<ReaderModel> FindReaderByTicket(int number)
        {
            var res = _service.FindReaderByTicket(number);
            return new ObservableCollection<ReaderModel>(res.Select(r => _mapper.Map(r)));
        }

        public ObservableCollection<ReaderModel> FindReadersByName(string query)
        {
            var res = _service.FindReadersByName(query);
            return new ObservableCollection<ReaderModel>(res.Select(r => _mapper.Map(r)));
        }

        public ObservableCollection<ReaderModel> GetPage(int offset, int amount)
        {
            var res = _service.GetPage(offset, amount);
            return new ObservableCollection<ReaderModel>(res.Select(r => _mapper.Map(r)));
        }

        public ObservableCollection<ReaderModel> GetReaders()
        {
            var res = _service.GetReaders();
            return new ObservableCollection<ReaderModel>(res.Select(r => _mapper.Map(r)));
        }

        public ReaderModel GetReaderWithInfo(int id) =>
            _mapper.Map(_service.GetReaderWithInfo(id));
    }
}
