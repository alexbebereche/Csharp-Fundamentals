using System;
using Xunit;

namespace GradeBook.Tests // we are in a namespace underneath the namespace that also has the Book class
{

    // a delegate is describing how a method looks like; name of the delegate
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod(){
            WriteLogDelegate log;

            // log = new WriteLogDelegate(ReturnMessage); // not invoking the method, just passing it
            log = ReturnMessage;
            log += ReturnMessage; // multi-cast delegates
            log += IncrementCount;

            var result = log("Hello");
            // Assert.Equal("Hello", result);
            Assert.Equal(3, count);
        }

        string ReturnMessage(string message){  // the return type and params need to match
            count += 1;
            return message;
        }

        string IncrementCount(string message){  // the return type and params need to match
            count += 1;
            return message.ToLower();
        }

        [Fact] 
        public void BookCalculateAnAverageGrade()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
            
        }
    
        [Fact] 
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
        }

        [Fact] 
        public void TwoVarsCanReferenceSameObjectAssertSame()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2); // doing someting similar to
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        [Fact] 
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New name");

            Assert.Equal("New name", book1.Name);
        }

        private void SetName(Book book1, string v)
        {
            book1.Name = v;
        }


        [Fact] 
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New name");

            Assert.Equal("Book 1", book1.Name);
        }

        [Fact] 
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New name");

            Assert.Equal("New name", book1.Name);
        }

        private void GetBookSetName(Book book1, string v)
        {
            book1 = new Book(v);
            //book.Name = name; !!!
        }

         private void GetBookSetNameRef(ref Book book1, string v)
        {
            book1 = new Book(v);
            //book.Name = name; !!!
        }

        [Fact]
        public void TestSetInt(){
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        [Fact]
        public void TestSetIntChange(){
            var x = GetInt();
            SetIntChange(ref x);

            Assert.Equal(42, x);
        }

        [Fact]
        public void StringBehaveLikeValueTypes(){
            string name = "alex";
            var upper = MakeUppercase(name);

            Assert.Equal("ALEX", upper);
            Assert.Equal("alex", name);
        }

        private string MakeUppercase(string name) // i have a pointer to a string, but i cant modify a string
        {
            return name.ToUpper(); // returns a copy of the string
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private void SetIntChange(ref int x)
        {
            x = 42;
        }

        private int GetInt(){
            return 3;
        }

        // dont want Fact here, we just call it from somewhere else
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
