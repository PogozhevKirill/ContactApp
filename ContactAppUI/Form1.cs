using ContactsApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactAppUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TestClasses();
        }

        private void TestClasses()
        {
            try
            {
                // Тестирование класса PhoneNumber
                PhoneNumber phoneNumber = new PhoneNumber { Number = 79123456789 };
                MessageBox.Show($"Phone number: {phoneNumber.Number}");

                // Тестирование класса Contact
                Contact contact = new Contact
                {
                    Name = "Иван",
                    Surname = "Иванов",
                    Phone = phoneNumber,
                    Birth = new DateTime(1990, 1, 1),
                    Email = "ivan.ivanov@example.com",
                    IdVk = "ivanov123"
                };
                MessageBox.Show($"Contact created: {contact.Name} {contact.Surname}, Phone: {contact.Phone.Number}, Birth: {contact.Birth}, Email: {contact.Email}, VkID: {contact.IdVk}");

                // Тестирование класса Project
                Project project = new Project();
                project._contactslistone.Add(contact);

                // Тестирование класса ProjectManager
                string filename = "ContactApp.txt";
                ProjectManager.SaveToFile(project, filename);
                Project loadedProject = ProjectManager.LoadFromFile(filename);
                MessageBox.Show($"Loaded project contains {loadedProject._contactslistone.Count} contacts.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
