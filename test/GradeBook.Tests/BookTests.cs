using System;
using Xunit;

namespace GradeBook.Tests // we are in a namespace underneath the namespace that also has the Book class
{
    public class BookTests
    {
        [Fact] // attribute - attached to test1
        public void BookCalculateAnAverageGrade()
        {
            // // arrange
            // var x = 5;
            // var y = 2;
            // var expected = 7;



            // // act
            // var actual = x + y;

            // // assert
            // Assert.Equal(expected, actual);



            // arrange

            var book = new Book("");
            book.AddGrade(7);
            book.AddGrade(4);
            book.AddGrade(7);

            // act
            var result =  book.ShowStatistics();

            // assert
            Assert.Equal(6, result);
        }


    }
}
