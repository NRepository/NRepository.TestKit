namespace NRepository.TestKit.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class EntityGeneratorTests
    {
        [Test]
        public void CheckGeneratrionWhenNoDefaultCtor()
        {
            var entity = EntityGenerator.Create<MyTestClass>();
        }
    }

    public class SimpleClass
    {
        public SimpleClass()
        {
        }

        public string AProperty { get; set; }
    }

    public class MyTestClass
    {
        private readonly MyCollectionClass _MyCollectionClass;
        public MyTestClass(MyCollectionClass myCollectionClass)
        {
            _MyCollectionClass = myCollectionClass;
        }
    }

    public class MyCollectionClass
    {
        public MyCollectionClass(IEnumerable<SimpleClass> items)
        {
            Items = items;
        }

        public MyCollectionClass(params SimpleClass[] items)
        {
            Items = items;
        }

        public IEnumerable<SimpleClass> Items
        {
            get;
            private set;
        }
    }

}
