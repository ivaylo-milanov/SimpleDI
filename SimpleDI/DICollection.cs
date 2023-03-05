namespace SimpleDI
{
    using System.Net.Http.Headers;
    using System.Runtime.CompilerServices;

    public class DICollection
    {
        private readonly IDictionary<Type, Type> implementations;

        public DICollection()
        {
            this.implementations = new Dictionary<Type, Type>();
        }

        public DIContainer CreateContainer() => new DIContainer(this.implementations);

        public void Register<TInter, TImpl>()
            where TImpl : TInter
        {
            this.implementations[typeof(TInter)] = typeof(TImpl);
        }

        public void RegisterAllFrom<TAssembly>()
        {
            var types = typeof(TAssembly)
                .Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in types)
            {
                var inter = type
                    .GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"I{type.Name}");

                if (inter != null)
                {
                    this.implementations[inter] = type;
                }
            }
        }
    }
}