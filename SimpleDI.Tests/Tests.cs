namespace SimpleDI.Tests
{
    using SimpleDI.App.Models;
    using SimpleDI.Tests.Models;

    public class Tests
    {
        [Test]
        public void CreatingCollectionAndBuildingTheContainer()
        {
            var collection = new DICollection();

            collection.Register<ISubDependency, SubDependency>();

            var container = collection.CreateContainer();

            var subDependency = container.Get<ISubDependency>();
            Assert.That(subDependency, Is.TypeOf<SubDependency>());
        }

        [Test]
        public void GettingMultipleResults()
        {
            var collection = new DICollection();
            collection.Register<IWriter, Writer>();
            collection.Register<IReader, Reader>();

            var constainer = collection.CreateContainer();
            var data = constainer.Resolve<IData>();

            Assert.That(data.reader, Is.TypeOf(Reader));
        }
    }
}