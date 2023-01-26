using Collections;

namespace Collection.UnitTests
{
    public class CollectionTests
    {
       

        [Test]
        public void Test_Collection_EmptyConstructor() {

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
    }










}