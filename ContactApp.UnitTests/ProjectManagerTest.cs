using NUnit.Framework;
using ContactsApp;
using System;
using System.IO;
using System.Collections.Generic;

namespace ContactsApp.Tests
{
    [TestFixture]
    public class ProjectManagerTests
    {
        private const string TestFilePath = "TestContactApp.txt";

        [SetUp]
        public void Setup()
        {
            // Удаляем тестовый файл, если он существует
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Удаляем тестовый файл, если он существует
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        [Test]
        public void SaveToFile_ShouldSaveDataToFile()
        {
            // Arrange
            var project = new Project();
            project._contactslistone = new List<Contact>
            {
                new Contact { Name = "Иван", Surname = "Иванов", Birth = new DateTime(1990, 1, 1) }
            };

            // Act
            ProjectManager.SaveToFile(project, TestFilePath);

            // Assert
            var loadedProject = ProjectManager.LoadFromFile(TestFilePath);
            Assert.Equals(1, loadedProject._contactslistone.Count);
            Assert.Equals("Иван", loadedProject._contactslistone[0].Name);
            Assert.Equals("Иванов", loadedProject._contactslistone[0].Surname);
            Assert.Equals(new DateTime(1990, 1, 1), loadedProject._contactslistone[0].Birth);
        }

        [Test]
        public void LoadFromFile_ExistingFile_ShouldLoadDataFromFile()
        {
            // Arrange
            var project = new Project();
            project._contactslistone = new List<Contact>
            {
                new Contact { Name = "Иван", Surname = "Иванов", Birth = new DateTime(1990, 1, 1) }
            };
            ProjectManager.SaveToFile(project, TestFilePath);

            // Act
            var loadedProject = ProjectManager.LoadFromFile(TestFilePath);

            // Assert
            Assert.Equals(1, loadedProject._contactslistone.Count);
            Assert.Equals("Иван", loadedProject._contactslistone[0].Name);
            Assert.Equals("Иванов", loadedProject._contactslistone[0].Surname);
            Assert.Equals(new DateTime(1990, 1, 1), loadedProject._contactslistone[0].Birth);
        }

        [Test]
        public void LoadFromFile_NonExistingFile_ShouldCreateEmptyFile()
        {
            // Act
            var loadedProject = ProjectManager.LoadFromFile(TestFilePath);

            // Assert
            Assert.Equals(0, loadedProject._contactslistone.Count);
        }

        [Test]
        public void LoadFromFile_Default_ShouldLoadDataFromDefaultFile()
        {
            // Arrange
            var project = new Project();
            project._contactslistone = new List<Contact>
            {
                new Contact { Name = "Иван", Surname = "Иванов", Birth = new DateTime(1990, 1, 1) }
            };
            ProjectManager.SaveToFile(project, ProjectManager.DocumentsPath);

            // Act
            var loadedProject = ProjectManager.LoadFromFile();

            // Assert
            Assert.Equals(1, loadedProject._contactslistone.Count);
            Assert.Equals("Иван", loadedProject._contactslistone[0].Name);
            Assert.Equals("Иванов", loadedProject._contactslistone[0].Surname);
            Assert.Equals(new DateTime(1990, 1, 1), loadedProject._contactslistone[0].Birth);
        }
    }
}
