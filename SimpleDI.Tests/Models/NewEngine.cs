namespace SimpleDI.App.Models
{
    public class NewEngine : IEngine
    {
        private readonly IDependency dependency;
        private readonly IData data;

        public NewEngine(IDependency dependency, IData data)
        {
            this.dependency = dependency;
            this.data = data;
        }

        public IDependency Dependency => this.dependency;

        public IData Data => this.data;

        public void Start()
        {
            Console.WriteLine("started...");
        }
    }
}
