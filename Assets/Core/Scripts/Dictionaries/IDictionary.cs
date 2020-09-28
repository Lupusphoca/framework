namespace PierreARNAUDET.Core.Dictionaries
{
    public interface IDictionary<T, U>
    {
        void Set(T key, U value);
        T GetKey(U value);
        U GetValue(T key);
    }
}