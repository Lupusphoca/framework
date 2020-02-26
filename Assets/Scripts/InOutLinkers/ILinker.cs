namespace Core.InOutLinker
{
    public interface ILinker<T>
    {
        void Continue(T data);
    }
}