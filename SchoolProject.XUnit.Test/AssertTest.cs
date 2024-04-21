using FluentAssertions;
namespace SchoolProject.XUnit.Test
{
    public class AssertTest
    {
        [Fact]
        public void Calc_2_Sum_3_Should_Be_5()
        {
            // Arrange
            int x = 2;
            int y = 3;
            int z;
            // Act
            z = x + y;
            // Assert

            Assert.Equal(5, z);
        }

        [Fact]
        public void Calc_2_Sum_3_Should_Be_5_with_fluentAsserction()
        {
            // Arrange
            int x = 2;
            int y = 3;
            int z;
            // Act
            z = x + y;
            // Assert

            z.Should().Be(2);
        }

        [Fact]
        public void Test_Welcome_Word()
        {
            // arrage 
            string word = "welcome";

            word.Should().StartWith("we").And.EndWith("me").And.BeOfType<string>();
        }
    }
}