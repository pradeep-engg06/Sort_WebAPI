using NUnit.Framework;

namespace API.Test
{
    public class Sorting_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 12, 32, 45, 68, 15, 65 },new int[] { 12, 15, 32, 45, 65, 68 })]
        [TestCase(new int[] { 32,65,78,44 }, new int[] { 32, 44, 65, 78 })]
        [TestCase(new int[] { 1,6,8,4,5,7,5,6,9,4,1,0,2,3 }, new int[] { 0, 1, 1, 2, 3, 4, 4, 5, 5, 6, 6, 7, 8, 9 })]
        public void TestBubbleSortMethod(int[] input, int[] result)
        {
            var Test = new API.Service.WithoutInbuildFunctionSortService();
           int[] FinalResult= Test.Sorting(input);

            Assert.AreEqual(result, FinalResult);
        }

        [TestCase(new int[] { 12, 32, 45, 68, 15, 65 }, new int[] { 12, 15, 32, 45, 65, 68 })]
        [TestCase(new int[] { 32, 65, 78, 44 }, new int[] { 32, 44, 65, 78 })]
        [TestCase(new int[] { 1, 6, 8, 4, 5, 7, 5, 6, 9, 4, 1, 0, 2, 3 }, new int[] { 0, 1, 1, 2, 3, 4, 4, 5, 5, 6, 6, 7, 8, 9 })]
        public void TestInsertionSortMethod(int[] input, int[] result)
        {
            var Test = new API.Service.InbuiltFunctionSortService();
            int[] FinalResult = Test.Sorting(input);

            Assert.AreEqual(result, FinalResult);
        }
       
    }
}