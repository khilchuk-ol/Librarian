using Librarian.Domain.Services.Abstract;
using Librarian.Gui.Models;
using Librarian.Gui.Services.Abstract;
using Librarian.Mappers.Abstract;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarian.Gui.Services.Impl
{
    public class RecordModelService : IRecordModelService
    {
        private IRecordMapper _mapper;
        private IRecordService _service;

        public RecordModelService(IRecordMapper mapper, IRecordService service)
        {
            if (service == null || mapper == null)
                throw new ArgumentNullException("Cannot pass null as argument for AuthorModelService constructor");
            _mapper = mapper;
            _service = service;
        }

        public ObservableCollection<RecordModel> GetRecords()
        {
            var res = _service.GetRecords();
            return new ObservableCollection<RecordModel>(res.Select(r => _mapper.Map(r)));
        }

        public RecordModel GetRecordWithInfo(int id) =>
            _mapper.Map(_service.GetRecordWithInfo(id));

        public ObservableCollection<RecordModel> GetPast(int readerId)
        {
            var res = _service.GetPast(readerId);
            return new ObservableCollection<RecordModel>(res.Select(r => _mapper.Map(r)));
        }

        public ObservableCollection<RecordModel> GetActive(int readerId)
        {
            var res = _service.GetActive(readerId);
            return new ObservableCollection<RecordModel>(res.Select(r => _mapper.Map(r)));
        }
    }
}
