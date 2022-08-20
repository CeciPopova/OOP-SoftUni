using NUnit.Framework;
using System;

namespace Book.Tests
{
    public class Tests
    {
        [Test]
        public void ConstructorWorksCorrectly()
        {
            Book book = new Book("Zero", "Test");
            string expectedName = "Zero";
            string actualName = book.BookName;
            Assert.AreEqual(expectedName, actualName);
            string expectedAutor = "Test";
            string actualAutor = book.Author;
            Assert.AreEqual(expectedAutor, actualAutor);
            int expectedCount = 0;
            int actualCount = book.FootnoteCount;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void InvalidNameTrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("", "Test");
            });
        }
        [Test]
        public void InvalidAutorTrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Zero", "");
            });
        }

        [Test]
        public void AddFootNoteWorksCorrectly()
        {

            Book book = new Book("Zero", "Test");
            book.AddFootnote(1, "text");
            int expectedCount = 1;
            int actualCount = book.FootnoteCount;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddFootNoteThrowsExceptionWhenTheFootnoteAlreadyExist()
        {

            Book book = new Book("Zero", "Test");
            book.AddFootnote(1, "text");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "textxt");
            });
        }

        [Test]
        public void FindFootNoteWorksCorrectly()
        {
            Book book = new Book("Zero", "Test");
            book.AddFootnote(1, "text");
            string expectedText = "Footnote #1: text";
            string actualText = book.FindFootnote(1);
            Assert.AreEqual(expectedText, actualText);
        }

        [Test]
        public void FindFootNoteThrowsExceptionWhenTheFootNoteNumberIsNotExist()
        {
            Book book = new Book("Zero", "Test");
            book.AddFootnote(1, "text");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(6);
            });
        }

        [Test]
        public void AlterFootNoteWorksCorrectly()
        {
            Book book = new Book("Zero", "Test");
            book.AddFootnote(1, "text");
            book.AlterFootnote(1, "newText");
            string expectedText = "Footnote #1: newText";
            string actualText = book.FindFootnote(1);
            Assert.AreEqual(expectedText, actualText);
        }
        [Test]
        public void AlterFootNoteThrowsExceptionWhenTheFoodNoteNumberIsNotExist()
        {
            Book book = new Book("Zero", "Test");
            book.AddFootnote(1, "text");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(4, "newText");
            });

        }
    }
}