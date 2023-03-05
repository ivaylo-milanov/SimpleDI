namespace SimpleDI.App.Models
{
    public class Writer : IWriter
    {
        public void WriteLine(string value) => Console.WriteLine(value);
    }
}
