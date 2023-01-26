using Collections;

namespace CollectionUnitTests
{
    public class CollectionTests
    {
        [Test]
        public void Test_Collection_EmptyConstructor1()
        {
            //Arrange and Act
            var collection = new Collection<int>();

            var actual = collection.ToString();
            var expected = "[]";

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(collection.Count == 0 && collection.Capacity == 16, Is.True);
        }
        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            //Arrange and Act
            var collection = new Collection<int>();

            var actual = collection.ToString();
            var expected = "[]";

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(collection.Count == 0 && collection.Capacity == 16, Is.True);
        }

        [Test]
        public void Test_Collection_SingleItem()
        {
            //Arrange and Act
            var collection = new Collection<int>(5);

            var actual = collection.ToString();
            var expected = "[5]";

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Collection_MultipleItems()
        {
            //Arrange and Act
            var collection = new Collection<int>(10, 15, 25, 100);

            var actual = collection.ToString();
            var expected = "[10, 15, 25, 100]";

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            //Arrange and Act
            var collection = new Collection<int>(10, 15, 25, 100);

            var actual = collection.Count;
            var expected = 4;
            var expectedCapacity = collection.Capacity;

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(expectedCapacity, Is.GreaterThan(actual));
        }

        [Test]
        public void Test_Collection_EnsureCapacity()
        {
            //Act and Arrange
            var collection = new Collection<int>();

            collection.Add(20);
            collection.Add(21);

            var actual = collection.Capacity;
            var expected = 16;


            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Collection_Add()
        {
            //Arrange and Act
            var collection = new Collection<int>(0, 55, 78, 90, 44, 85, 54, 3);

            //Act
            collection.Add(1000);
            collection.Add(29);
            var actual = collection.Count;
            var expected = 10;

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
            Assert.True(actual == expected);
            Assert.That(collection.Capacity, Is.EqualTo(16));
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            //Arrange and Act
            var collection = new Collection<int>(7, 8, 12);

            //Act
            var item = collection[1];
            

            //Assert
            Assert.That(item.ToString(), Is.EqualTo("8"));
        }

        [Test]
        public void Test_Collection_GetByIvalidIndex()
        {
            //Arrange and Act
            var collection = new Collection<int>(7, 8, 12);

            //Assert
            Assert.That(() => { var item = collection[3]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        
        [Test]
        public void Test_Collection_SetByIndex()
        {
            //Arrange and Act
            var collection = new Collection<int>(78, 8, 98);

            //Act
            collection[1] = 88;

            //Assert
            Assert.That(collection.ToString(), Is.EqualTo("[78, 88, 98]"));
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            //Arrange and Act
            var collection = new Collection<int>(78, 8, 98);

            //Assert and Act
            Assert.That(() => collection[-1] = 8,
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }


        [Test]
        public void Test_Collection_InsertAt()
        {
            //Arrange and Act
            var collection = new Collection<int>(7, 8, 12);

            collection.InsertAt(2, 19);
            collection.InsertAt(0, 20);

            //Assert
            Assert.That(collection.ToString(), Is.EqualTo("[20, 7, 8, 19, 12]"));
            Assert.That(collection.Count, Is.LessThan(collection.Capacity));
        }

        [Test]
        public void Test_Collection_RemoveAt()
        {
            //Arrange and Act
            var collection = new Collection<int>(222, 15, 78, 16, 19, 1);

            collection.RemoveAt(0);
            collection.RemoveAt(4);

            //Assert
            Assert.That(collection.ToString(), Is.EqualTo("[15, 78, 16, 19]"));
            Assert.That(collection.Count, Is.EqualTo(4));
        }

        [Test]
        public void Test_Collection_ClearCollection()
        {
            //Arrange and Act
            var collection = new Collection<int>(222, 15, 78, 16, 19, 1);

            collection.Clear();

            //Assert
            Assert.That(collection.ToString(), Is.EqualTo("[]"));
            Assert.That(collection.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_Collection_Exchange()
        {
            //Arrange and Act
            var collection = new Collection<int>(222, 15, 78, 16, 19, 1);

            collection.Exchange(1, 2);

            //Assert
            Assert.That(collection.ToString(), Is.EqualTo("[222, 78, 15, 16, 19, 1]"));
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            //Arrange and Act
            var collection = new Collection<int>();

            collection.AddRange(222, 78, 15, 16, 19, 1);

            //Assert
            Assert.That(collection.ToString(), Is.EqualTo("[222, 78, 15, 16, 19, 1]"));
        }

        [Test]
        public void EnsureCapacity_UsesDefaultCapacityWhenArrayIsEmpty()
        {
            // Arrange
            var collection = new Collection<int>();

            //Act and Assert
            Assert.That(collection.Capacity, Is.EqualTo(16));
        }
    }
}
