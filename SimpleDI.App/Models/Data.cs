namespace SimpleDI.App.Models
{
    public class Data : IData
    {
        public Data(IReader reader, IWriter writer)
        {
            this.Reader = reader;
            this.Writer = writer;
        }

        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }
    }
}
