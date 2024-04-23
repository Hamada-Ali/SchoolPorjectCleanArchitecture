using System.Collections;

namespace SchoolProject.XUnit.Test.TestModels
{
    public class PassDataToParamUsingMemberData : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> GetParamData()
        {
            return new List<object[]>
            {
                new object[] {69},
                new object[] {44}
            };
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return (IEnumerator<object[]>)GetParamData();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
