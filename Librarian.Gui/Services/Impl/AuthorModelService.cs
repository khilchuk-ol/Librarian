using Librarian.Domain.Services.Abstract;
using Librarian.Gui.Models;
using Librarian.Gui.Services.Abstract;
using Librarian.Mappers.Abstract;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarian.Gui.Services.Impl
{
    public class AuthorModelService : IAuthorModelService
    {
        private IAuthorMapper _mapper;
        private IAuthorService _service;

        public AuthorModelService(IAuthorService service, IAuthorMapper mapper)
        {
            if (service == null || mapper == null)
                throw new ArgumentNullException("Cannot pass null as argument for AuthorModelService constructor");
            _mapper = mapper;
            _service = service;
        }

        public ObservableCollection<AuthorModel> FindAuthorsByName(string query)
        {
            var res = _service.FindAuthorsByName(query);
            return new ObservableCollection<AuthorModel>(res.Select(a => _mapper.Map(a)));
        }

        public ObservableCollection<AuthorModel> GetAuthors()
        {
            var res = _service.GetAuthors();
            return new ObservableCollection<AuthorModel>(res.Select(a => _mapper.Map(a)));
        }

        public AuthorModel GetAuthorWithInfo(int id) =>
            _mapper.Map(_service.GetAuthorWithInfo(id));
    }
}
