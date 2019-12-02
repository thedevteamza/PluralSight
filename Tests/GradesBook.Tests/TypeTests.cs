using System;
using Xunit;
using GradesBook;

namespace GradesBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Edward";
            var upper = MakeUppercase(name);

            Assert.Equal("Edward", name);
            Assert.Equal("EDWARD", upper);
        }

        private string MakeUppercase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();

            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book1");

            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book1");

            GetBookSetName(book1, "New Name");

            Assert.Equal("Book1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book1");

            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferrentObjects()
        {
            var arrange1 = new Book("Book1");
            var arrange2 = new Book("Book2");

            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal(arrange1.Name, book1.Name);
            Assert.Equal(arrange2.Name, book2.Name);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var arrange1 = new Book("Book1");
            var arrange2 = new Book("Book2");

            var book1 = GetBook("Book1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
