
using ConsolePlayGround;

namespace ConsolePlayGroundTest
{
    public class DatePlayTests
    {
        [Fact]
        public void AddWeeksToDateTest()
        {
            // setup
            DateTime initialDate = new DateTime(2022, 7, 25);
            DateTime expectedDate = new DateTime(2022, 10, 17);
            // execute
            DateTime returnedDate = DatePlay.AddWeeksToDate(initialDate, 12);
            // assert
            Assert.Equal(expectedDate, returnedDate);

        }
    }
}
