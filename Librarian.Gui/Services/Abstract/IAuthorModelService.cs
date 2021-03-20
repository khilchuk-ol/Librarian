using Librarian.Gui.Models;
using System.Collections.ObjectModel;

namespace Librarian.Gui.Services.Abstract
{
    public interface IAuthorModelService
    {
        ObservableCollection<AuthorModel> FindAuthorsByName(string query);
        AuthorModel GetAuthorWithInfo(int id);
        ObservableCollection<AuthorModel> GetAuthors();
    }
}
