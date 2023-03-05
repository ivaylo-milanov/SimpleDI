namespace SimpleDI.App.Models
{
    using SimpleDI.Tests.Models;

    public class Dependency : IDependency
    {
        private readonly ISubDependency subDependency;

        public Dependency(ISubDependency subDependency)
        {
            this.subDependency = subDependency;
        }

        public ISubDependency SubDependency => this.subDependency;
    }
}
