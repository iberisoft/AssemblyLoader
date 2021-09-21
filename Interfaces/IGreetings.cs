namespace Interfaces
{
    public interface IGreetings<T>
    {
        string Print(T obj);
    }
}
