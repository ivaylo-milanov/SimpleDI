namespace SimpleDI.App
{
    using SimpleDI.App.Models;
    using SimpleDI;

    public class Program
    {
        public static void Main(string[] args)
        {
            var collection = new DICollection();
            collection.RegisterAllFrom<Program>();

            var container = collection.CreateContainer();

            var engine = container.Resolve<Engine>();
            var newEngine = container.Resolve<NewEngine>();

            engine.Start();
            newEngine.Start();
        }
    }
}