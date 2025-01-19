using NUnit.Framework;
using ContactsApp;
using System;

namespace ContactsApp.Tests
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void SetValidName_ShouldSetCorrectly()
        {
            // Arrange
            var contact = new Contact();
            string validName = "Иван";

            // Act
            contact.Name = validName;

            // Assert
            Assert.Equals(validName, contact.Name);
        }

        [Test]
        public void SetInvalidName_Empty_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            string invalidName = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.Name = invalidName);
        }

        [Test]
        public void SetInvalidName_TooLong_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            string invalidName = new string('a', 51);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.Name = invalidName);
        }

        [Test]
        public void SetValidSurname_ShouldSetCorrectly()
        {
            // Arrange
            var contact = new Contact();
            string validSurname = "Иванов";

            // Act
            contact.Surname = validSurname;

            // Assert
            Assert.Equals(validSurname, contact.Surname);
        }

        [Test]
        public void SetInvalidSurname_Empty_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            string invalidSurname = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.Surname = invalidSurname);
        }

        [Test]
        public void SetInvalidSurname_TooLong_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            string invalidSurname = new string('a', 51);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.Surname = invalidSurname);
        }

        [Test]
        public void SetValidPhone_ShouldSetCorrectly()
        {
            // Arrange
            var contact = new Contact();
            var validPhone = new PhoneNumber { Number = 79123456789 };

            // Act
            contact.Phone = validPhone;

            // Assert
            Assert.Equals(validPhone, contact.Phone);
        }

        [Test]
        public void SetValidBirth_ShouldSetCorrectly()
        {
            // Arrange
            var contact = new Contact();
            DateTime validBirth = new DateTime(1990, 1, 1);

            // Act
            contact.Birth = validBirth;

            // Assert
            Assert.Equals(validBirth, contact.Birth);
        }

        [Test]
        public void SetInvalidBirth_FutureDate_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            DateTime invalidBirth = DateTime.Now.AddDays(1);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.Birth = invalidBirth);
        }

        [Test]
        public void SetInvalidBirth_Before1900_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            DateTime invalidBirth = new DateTime(1899, 12, 31);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.Birth = invalidBirth);
        }

        [Test]
        public void SetValidEmail_ShouldSetCorrectly()
        {
            // Arrange
            var contact = new Contact();
            string validEmail = "ivan.ivanov@example.com";

            // Act
            contact.Email = validEmail;

            // Assert
            Assert.Equals(validEmail, contact.Email);
        }

        [Test]
        public void SetInvalidEmail_Empty_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            string invalidEmail = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.Email = invalidEmail);
        }

        [Test]
        public void SetInvalidEmail_TooLong_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            string invalidEmail = new string('a', 51) + "@example.com";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.Email = invalidEmail);
        }

        [Test]
        public void SetInvalidEmail_NoAtSymbol_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            string invalidEmail = "ivan.ivanovexample.com";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.Email = invalidEmail);
        }

        [Test]
        public void SetValidIdVk_ShouldSetCorrectly()
        {
            // Arrange
            var contact = new Contact();
            string validIdVk = "ivanov123";

            // Act
            contact.IdVk = validIdVk;

            // Assert
            Assert.Equals(validIdVk, contact.IdVk);
        }

        [Test]
        public void SetInvalidIdVk_Empty_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            string invalidIdVk = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.IdVk = invalidIdVk);
        }

        [Test]
        public void SetInvalidIdVk_TooLong_ShouldThrowArgumentException()
        {
            // Arrange
            var contact = new Contact();
            string invalidIdVk = new string('a', 16);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => contact.IdVk = invalidIdVk);
        }

        [Test]
        public void Clone_ShouldCreateCorrectCopy()
        {
            // Arrange
            var original = new Contact
            {
                Name = "Иван",
                Surname = "Иванов",
                Phone = new PhoneNumber { Number = 79123456789 },
                Birth = new DateTime(1990, 1, 1),
                Email = "ivan.ivanov@example.com",
                IdVk = "ivanov123"
            };

            // Act
            var clone = (Contact)original.Clone();

            // Assert
            Assert.AreEqual(original.Name, clone.Name);
            Assert.Equals(original.Surname, clone.Surname);
            Assert.Equals(original.Phone.Number, clone.Phone.Number);
            Assert.Equals(original.Birth, clone.Birth);
            Assert.Equals(original.Email, clone.Email);
            Assert.Equals(original.IdVk, clone.IdVk);
        }
    }
}
