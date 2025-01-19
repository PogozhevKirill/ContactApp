using NUnit.Framework;
using ContactsApp;
using System;
using System.Collections.Generic;

namespace ContactsApp.Tests
{
    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public void Sort_ShouldSortContactsBySurname()
        {
            // Arrange
            var project = new Project();
            project._contactslistone = new List<Contact>
            {
                new Contact { Surname = "Иванов" },
                new Contact { Surname = "Петров" },
                new Contact { Surname = "Сидоров" }
            };

            // Act
            var sortedContacts = project.Sort(project._contactslistone);

            // Assert
            Assert.Equals("Иванов", sortedContacts[0].Surname);
            Assert.Equals("Петров", sortedContacts[1].Surname);
            Assert.Equals("Сидоров", sortedContacts[2].Surname);
        }

        [Test]
        public void Birthday_ShouldReturnProjectWithBirthdayContacts()
        {
            // Arrange
            var project = new Project();
            project._contactslistone = new List<Contact>
            {
                new Contact { Birth = new DateTime(1990, 1, 1) },
                new Contact { Birth = new DateTime(1990, 1, 2) },
                new Contact { Birth = new DateTime(1990, 1, 1) }
            };
            DateTime today = new DateTime(1990, 1, 1);

            // Act
            var birthdayProject = Project.Birthday(project, today);

            // Assert
            Assert.Equals(2, birthdayProject._contactslistone.Count);
            Assert.Equals(new DateTime(1990, 1, 1), birthdayProject._contactslistone[0].Birth);
            Assert.Equals(new DateTime(1990, 1, 1), birthdayProject._contactslistone[1].Birth);
        }

        [Test]
        public void Birthday_ShouldReturnEmptyProjectIfNoBirthdayMatches()
        {
            // Arrange
            var project = new Project();
            project._contactslistone = new List<Contact>
            {
                new Contact { Birth = new DateTime(1990, 1, 1) },
                new Contact { Birth = new DateTime(1990, 1, 2) },
                new Contact { Birth = new DateTime(1990, 1, 3) }
            };
            DateTime today = new DateTime(1990, 1, 4);

            // Act
            var birthdayProject = Project.Birthday(project, today);

            // Assert
            Assert.Equals(0, birthdayProject._contactslistone.Count);
        }
    }
}
