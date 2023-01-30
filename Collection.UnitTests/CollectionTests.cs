using Collections;

namespace Collection.UnitTests
{
    public class CollectionTests
    {


        [Test]
        public void Test_Collection_EmptyConstructor()
        {

            var coll = new Collection<int>();
            Assert.That(coll.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {

            var nums = new Collection<int>(6);
            Assert.That(nums[0], Is.EqualTo(6));
        }
        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {

            var nums = new Collection<int>(6, 9);
            Assert.That(nums.ToString(), Is.EqualTo("[6, 9]"));
        }

        [Test]
        public void Test_Collection_Add()
        {

            var nums = new Collection<int>(7);
            Assert.That(nums[0], Is.EqualTo(7));
        }
        [Test]
        public void Test_Collection_AddTwoNums()
        {

            var nums = new Collection<int>(6, 8, 9);
            Assert.That(nums.ToString(), Is.EqualTo("[6, 8, 9]"));
        }
        [Test]
        public void Test_Collection_AddWithGrow()
        {

            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));

        }
        [Test]
        public void Test_Collection_AddRange()
        {
            var nums = new Collection<int>(3);
            Assert.That(nums[0], Is.InRange(0, 5));
        }
        [Test]
        public void Test_Collection_AddRangeNegative()
        {
            var nums = new Collection<int>(-1);
            Assert.That(nums[0], Is.InRange(-2, 5));
        }
        [Test]
        public void Test_Collection_GetByIndex()
        {
            var nums = new Collection<int>(2, 3, 5);
            Assert.That(nums[1], Is.EqualTo(3));
        }
        [Test]
        public void Test_Collection_GetByIndexString()
        {
            var names = new Collection<string>("Ana", "Dimitar");
            Assert.That(names[0], Is.EqualTo("Ana"));
            Assert.That(names[1], Is.EqualTo("Dimitar"));

        }
        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var names = new Collection<string>("Maria", "Ivan");
            Assert.That(() => { var name = names[-1]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[3]; }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString, Is.EqualTo("[Maria, Ivan]"));
        }
        [Test]
        public void Test_Collection_SetByIndex()
        {
            var nums = new Collection<int>(2, 3, 5);
            nums[0] = 1;
            var expected = "[1, 3, 5]";

            Assert.That(expected, Is.EqualTo(nums.ToString()));
        }
        [Test]
        public void Test_Collection_SetByIndexString()
        {
            var students = new Collection<string>("Petar", "Tedi");
            students[1] = "Moni";
            var expected = "[Petar, Moni]";

            Assert.That(expected, Is.EqualTo(students.ToString()));

        }
        [Test]
        public void Test_Collection_SetByInvalidIndexString()
        {
            var names = new Collection<string>("Maria", "Ivan");
            Assert.That(() => { names[-1] = "Moni"; }, Throws.InstanceOf<ArgumentOutOfRangeException>(), "Invalid index!");
            Assert.That(() => { names[3] = "Tedi"; }, Throws.InstanceOf<ArgumentOutOfRangeException>(), "Invalid index!");
            Assert.That(names.ToString, Is.EqualTo("[Maria, Ivan]"));

        }
        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>(3, 19);

            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(16));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));

        }

        [Test]
        public void Test_Collection_InsertAtStart()
        {
            var coll = new Collection<int>();
            var expected = "[3, 6]";

            coll.InsertAt(0, 3);
            coll.InsertAt(1, 6);

            Assert.That(expected, Is.EqualTo(coll.ToString()));

        }
        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var coll = new Collection<int>();
            var expected = "[3, 6, 9]";

            coll.InsertAt(0, 3);
            coll.InsertAt(1, 6);
            coll.InsertAt(2, 9);

            Assert.That(expected, Is.EqualTo(coll.ToString()));
        }
        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            var coll = new Collection<int>();
            var expected = "[3, 5, 6, 9]";

            coll.InsertAt(0, 3);
            coll.InsertAt(1, 6);
            coll.InsertAt(2, 9);
            coll.InsertAt(1, 5);

            Assert.That(expected, Is.EqualTo(coll.ToString()));

        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            var coll = new Collection<int>();
            coll.AddRange(Enumerable.Range(3, 5).ToArray());
            var expected = "[3, 4, 333, 5, 6, 7]";

            coll.InsertAt(2, 333);

            Assert.That(expected, Is.EqualTo(coll.ToString()));

        }
        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var coll = new Collection<int>(3, 333);
            var expected = "[3, 333]";

            Assert.Multiple(() =>
            {
                Assert.That(() => { coll[-1] = 1; }, Throws.InstanceOf<ArgumentOutOfRangeException>(), "Invalid index!");
                Assert.That(expected, Is.EqualTo(coll.ToString()));
            });
        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var coll = new Collection<int>(3, 5, 7);
            var expected = "[3, 7, 5]";

            coll.Exchange(2, 1);

            Assert.That(expected, Is.EqualTo(coll.ToString()));
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            var coll = new Collection<int>(3, 5, 7);
            var expected = "[7, 5, 3]";

            coll.Exchange(0, 2);

            Assert.That(expected, Is.EqualTo(coll.ToString()));
        }
        [Test]
        public void Test_Collection_ExchangeInvalidIndexes()
        {
            var coll = new Collection<int>(3, 5, 7);
            var expected = "[3, 5, 7]";

            Assert.Multiple(() =>
            {
                Assert.That(() => { coll[-1] = 1; }, Throws.InstanceOf<ArgumentOutOfRangeException>(), "Invalid index!");
                Assert.That(expected, Is.EqualTo(coll.ToString()));
            });
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var coll = new Collection<int>(3, 5, 7);
            var expected = "[5, 7]";

            coll.RemoveAt(0);

            Assert.That(expected, Is.EqualTo(coll.ToString()));
        }
        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            var coll = new Collection<int>(3, 5, 7);
            var expected = "[3, 5]";

            coll.RemoveAt(2);

            Assert.That(expected, Is.EqualTo(coll.ToString()));
        }
        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            var coll = new Collection<int>(3, 5, 7);
            var expected = "[3, 7]";

            coll.RemoveAt(1);

            Assert.That(expected, Is.EqualTo(coll.ToString()));
        }
        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()
        {
            var coll = new Collection<int>(3, 5, 7);
            var expected = "[3, 5, 7]";

            Assert.Multiple(() =>
            {
                Assert.That(() => { coll[-1] = 1; }, Throws.InstanceOf<ArgumentOutOfRangeException>(), "Invalid index!");
                Assert.That(expected, Is.EqualTo(coll.ToString()));
            });
        }
        [Test]
        public void Test_Collection_RemoveAll()
        {
            var coll = new Collection<int>(3, 5, 7);
            var expected = "[]";

            coll.RemoveAt(0);
            coll.RemoveAt(0);
            coll.RemoveAt(0);

            Assert.That(expected, Is.EqualTo(coll.ToString()));
        }
        [Test]
        public void Test_Collection_Clear()
        {
            var coll = new Collection<int>(3, 5, 7);
            var expected = "[]";

            coll.Clear();

            Assert.That(expected, Is.EqualTo(coll.ToString()));
        }
        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var coll = new Collection<int>(3, 5);

            Assert.AreEqual(coll.Count, 2);
            Assert.That(coll.Capacity, Is.GreaterThan(coll.Count));

        }
        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            var coll = new Collection<string>();
            Assert.That(coll.ToString(), Is.EqualTo("[]"));

        }
        [Test]
        public void Test_Collection_ToStringSingle()
        {
            var coll = new Collection<string>("Moni");
            var expected = "[Moni]";
            Assert.That(coll.ToString(), Is.EqualTo(expected));
        }
        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            var coll = new Collection<string>("Moni", "Tedi");
            var expected = "[Moni, Tedi]";

            Assert.That(coll.ToString(), Is.EqualTo(expected));
        }
        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Tedi", "Moni");
            var nums = new Collection<int>(1, 3);
            var dates = new Collection<DateTime>();
            var nested = new Collection<object>(names, nums, dates);
            string nestedToString = nested.ToString();
            Assert.That(nestedToString,
              Is.EqualTo("[[Tedi, Moni], [1, 3], []]"));

        }
        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }

        //Data-Driven Testing
        [TestCase("Ana", 0, "Ana")]
        [TestCase("Ana,Dimitar,Moni", 0, "Ana")]
        [TestCase("Ana,Dimitar,Moni", 1, "Dimitar")]
        [TestCase("Ana,Dimitar,Moni", 2, "Moni")]

        public void Test_Collection_GetByValidIndexStringDDT(
            string data, int index, string expected)
        {
            var items = new Collection<string>(data.Split(","));
            var item = items[index];
            Assert.That(item, Is.EqualTo(expected));
        }

        [TestCase("33", 0, 33)]
        [TestCase("3,66,99", 0, 3)]
        [TestCase("3,66,99", 1, 66)]
        [TestCase("3,66,99", 2, 99)]

        public void Test_Collection_GetByValidIndexDDT(
            string data, int index, int expected)
        {
            var items = new Collection<string>(data.Split(","));
            var item = items[index];
            Assert.That(item, Is.EqualTo(expected.ToString()));
        }
        [TestCase("3, 5", 2)]
        [TestCase("1, 9", -1)]

        public void Test_Collection_GetByInvalidIndexDDT(
            string data, int index)
        {
            var items = new Collection<string>(data.Split(",", StringSplitOptions.RemoveEmptyEntries));

            Assert.That(() => items[index], Throws.InstanceOf<ArgumentOutOfRangeException>());

        }
        [TestCase("3", 0, "3")]
        [TestCase("2,6", 0, "2")]
        [TestCase("2,6", 1, "6")]
        [TestCase("2,6,7,9", 3, "9")]

        public void Test_Collection_AddDDT(
            string data, int index, int expected)
        {
            var items = new Collection<string>(data.Split(","));
            var item = items[index];
            Assert.That(item, Is.EqualTo(expected.ToString()));
        }
        
        [TestCase("3", 0, "3")]
        public void Test_Collection_InsertAtMiddleDDT(
            string data, int index, string expected)
        {
            var items = new Collection<string>(data.Split(","));
            var item = items[index];

            Assert.That(item, Is.EqualTo(expected.ToString()));
        }

    }

}  