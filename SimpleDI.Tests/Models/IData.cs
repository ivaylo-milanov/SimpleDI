namespace SimpleDI.App.Models
{
    public interface IData
    {
        IReader reader { get; }
        IWriter writer { get; }
    }
}
