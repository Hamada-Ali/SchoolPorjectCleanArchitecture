using System.Collections;

namespace SchoolProject.XUnit.Test.TestModels
{
    public class PassDataUsingClassData : IEnumerable<object[]>
    {
        private readonly List<object[]> data = new List<object[]>()
        {
            new object[] {66},
            new object[] {69}
        };
        public IEnumerator<object[]> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
