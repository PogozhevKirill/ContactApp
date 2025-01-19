using NUnit.Framework;
using ContactsApp;
using System;

namespace ContactsApp.Tests
{
    [TestFixture]
    public class PhoneNumberTests
    {
        [Test]
        public void SetValidPhoneNumber_ShouldSetCorrectly()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            long validNumber = 79123456789;

            // Act
            phoneNumber.Number = validNumber;

            // Assert
            Assert.Equals(validNumber, phoneNumber.Number);
        }

        [Test]
        public void SetInvalidPhoneNumber_LessThan11Digits_ShouldThrowArgumentException()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            long invalidNumber = 791234567;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => phoneNumber.Number = invalidNumber);
        }

        [Test]
        public void SetInvalidPhoneNumber_MoreThan11Digits_ShouldThrowArgumentException()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            long invalidNumber = 791234567890;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => phoneNumber.Number = invalidNumber);
        }

        [Test]
        public void SetInvalidPhoneNumber_NotStartWith7_ShouldThrowArgumentException()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            long invalidNumber = 89123456789;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => phoneNumber.Number = invalidNumber);
        }

        [Test]
        public void SetInvalidPhoneNumber_NonNumeric_ShouldThrowArgumentException()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            string invalidNumber = "7912345678A";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => phoneNumber.Number = long.Parse(invalidNumber));
        }
    }
}
