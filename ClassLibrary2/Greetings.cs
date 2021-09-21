using Interfaces;

namespace ClassLibrary2
{
    public class Greetings<T> : IGreetings<T>
    {
        public string Print(T obj)
        {
            return obj.ToString();
        }
    }
}
