using Librarian.Gui.Models;
using System.Collections.ObjectModel;

namespace Librarian.Gui.Services.Abstract
{
    public interface IBookModelService
    {
        ObservableCollection<BookModel> FindBooksByTitle(string title);
        ObservableCollection<BookModel> FindBooksByAuthor(int authorId);
        BookModel GetBookWithInfo(int id);
        ObservableCollection<BookModel> GetBooks();
    }
}
