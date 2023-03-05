namespace SimpleDI
{
    public interface IDIContainer
    {
        TInter Get<TInter>()
            where TInter : class;

        TInstance Resolve<TInstance>() 
            where TInstance : class;
    }
}
