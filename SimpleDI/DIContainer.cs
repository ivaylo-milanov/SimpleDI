namespace SimpleDI
{
    using System.Reflection.Metadata;

    public class DIContainer : IDIContainer
    {
        private readonly IDictionary<Type, Type> implementations;

        public DIContainer(IDictionary<Type, Type> implementations)
        {
            this.implementations = implementations;
        }

        public TInter Get<TInter>()
            where TInter : class
            => (TInter)this.Get(typeof(TInter));

        private object Get(Type type)
        {
            if (!this.implementations.ContainsKey(type))
            {
                throw new ArgumentNullException($"{type.FullName} is not registered");
            }

            var implementationType = this.implementations[type];

            return this.CreateInstance(implementationType);
        }

        public TInstance Resolve<TInstance>()
            where TInstance : class
            => (TInstance)this.CreateInstance(typeof(TInstance));

        private object CreateInstance(Type instaceType)
        {
            var constructors = instaceType.GetConstructors();

            if (constructors.Length != 1)
            {
                throw new InvalidOperationException("This class has more than one constructor!");
            }

            var constructor = constructors[0];
            var constructorParams = constructor.GetParameters();

            if (!constructorParams.Any())
            {
                return Activator.CreateInstance(instaceType);
            }

            var parameters = new object[constructorParams.Length];

            for (int i = 0; i < constructorParams.Length; i++)
            {
                var parameterType = constructorParams[i].ParameterType;
                var instance = parameterType.IsInterface
                    ? this.Get(parameterType)
                    : this.CreateInstance(parameterType);
                parameters[i] = instance;
            }

            return constructor.Invoke(parameters);
        }

        
    }
}
