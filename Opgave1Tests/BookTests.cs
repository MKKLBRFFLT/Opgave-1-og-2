using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opgave1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1.Tests
{
    [TestClass()]
    public class BookTests
    {
        [TestMethod]
        public void IsValid_ValidBook_Pass()
        {
            // Arrange
            var book = new Book
            {
                ID = 1,
                Title = "Neuromancer",
                Price = 10
            };

            // Act
            var isValid = book.IsValid();

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsIDValid_ValidID_Pass()
        {
            // Arrange
            var book = new Book
            {
                ID = 1,
                Title = "Sample Book",
                Price = 10.99
            };

            // Act
            var isIDValid = book.IsIDValid();

            // Assert
            Assert.IsTrue(isIDValid);
        }

        [TestMethod]
        public void IsIDValid_NegativeID_Fail()
        {
            // Arrange
            var book = new Book
            {
                ID = -1,
                Title = "Sample Book",
                Price = 10.99
            };

            // Act
            var isIDValid = book.IsIDValid();

            // Assert
            Assert.IsFalse(isIDValid);
        }

        [TestMethod]
        public void IsIDValid_ZeroID_Pass()
        {
            // Arrange
            var book = new Book
            {
                ID = 0,
                Title = "Sample Book",
                Price = 10.99
            };

            // Act
            var isIDValid = book.IsIDValid();

            // Assert
            Assert.IsTrue(isIDValid);
        }

        [TestMethod]
        public void IsValid_EmptyTitle_Fail()
        {
            // Arrange
            var book = new Book
            {
                ID = 1,
                Title = "",
                Price = 10
            };

            // Act
            var isValid = book.IsValid();

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValid_ShortTitle_Fail()
        {
            // Arrange
            var book = new Book
            {
                ID = 1,
                Title = "N",
                Price = 10
            };

            // Act
            var isValid = book.IsValid();

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValid_NegativePrice_Fail()
        {
            // Arrange
            var book = new Book
            {
                ID = 1,
                Title = "Neuromancer",
                Price = -10
            };

            // Act
            var isValid = book.IsValid();

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsValid_PriceTooHigh_Fail()
        {
            // Arrange
            var book = new Book
            {
                ID = 1,
                Title = "Neuromancer",
                Price = 1201
            };

            // Act
            var isValid = book.IsValid();

            // Assert
            Assert.IsFalse(isValid);
        }

        

        [TestMethod]
        public void ToString_Formatting_Pass()
        {
            // Arrange
            var book = new Book
            {
                ID = 1,
                Title = "Neuromancer",
                Price = 10
            };

            // Act
            var result = book.ToString();

            // Assert
            Assert.AreEqual("{ID=1, Title=Neuromancer, Price=10}", result);
        }

        //Repository tests
        [TestMethod]
        public void Add_ValidBook_Pass()
        {
            // Arrange
            var repository = new BooksRepository();
            var bookToAdd = new Book
            {
                Title = "Neuromancer",
                Price = 10
            };

            // Act
            var addedBook = repository.Add(bookToAdd);

            // Assert
            Assert.IsNotNull(addedBook);
            Assert.AreEqual("Neuromancer", addedBook.Title);
            Assert.AreEqual(10, addedBook.Price);
        }

        [TestMethod]
        public void Update_ExistingBookWithValidData_Pass()
        {
            // Arrange
            var repository = new BooksRepository();
            var originalBook = repository.Add(new Book
            {
                Title = "Neuromancer",
                Price = 10
            });
            var updatedBookData = new Book
            {
                Title = "Chaos",
                Price = 15
            };

            // Act
            var updatedBook = repository.Update(originalBook.ID, updatedBookData);

            // Assert
            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(updatedBookData.Title, updatedBook.Title);
            Assert.AreEqual(updatedBookData.Price, updatedBook.Price);
        }

        [TestMethod]
        public void Delete_ExistingBook_Pass()
        {
            // Arrange
            var repository = new BooksRepository();
            var bookToDelete = repository.Add(new Book
            {
                Title = "Chaos",
                Price = 15
            });

            // Act
            var deletedBook = repository.Delete(bookToDelete.ID);

            // Assert
            Assert.IsNotNull(deletedBook);
            Assert.AreEqual("Chaos", deletedBook.Title);
            Assert.AreEqual(15, deletedBook.Price);
        }
    }
}