using Interfaces;

namespace ClassLibrary2
{
    class Greetings2<T> : IGreetings<T>
    {
        public string Print(T obj)
        {
            return obj.ToString() + "!";
        }
    }
}
