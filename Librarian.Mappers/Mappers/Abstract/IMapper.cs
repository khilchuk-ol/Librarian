namespace Librarian.Mappers.Abstract
{
    public interface IMapper<T, U>
    {
        U Map(T from);
        T Map(U from);
        void Map(U from, T to);
    }
}
