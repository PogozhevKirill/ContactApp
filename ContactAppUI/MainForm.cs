using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\ContactApp.txt";

        private Project _project = new Project();

        public MainForm()
        {
            InitializeComponent();
            BirthTimePicker1.MaxDate = DateTime.Now.AddDays(1);
            if (ProjectManager.LoadFromFile(_path) != null)
            {
                _project = ProjectManager.LoadFromFile(_path);
            }
            ShowListBox();
            ContactlistBox.Sorted = true;
            ///           Birthday();
        }

        ///        private void Birthday()
        ///        {
        ///        Project birth = Project.Birthday(_project, DateTime.Today);
        ///            for (int i = 0; i != birth._contactslistone.Count; i++)
        ///            {
        ///        Birthdaylabel10.Text = Birthdaylabel10.Text + birth._contactslistone[i].Surname + ". ";
        ///    }
        ///    }

        public void ShowListBox()
        {
            foreach (Contact t in _project._contactslistone)
            {
                ContactlistBox.Items.Add(t.Surname);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public List<Contact> _contactslistone = new List<Contact>();


        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new AddContact();
            var UpdatedDate = form2.Data;
            var i = form2.ShowDialog();
            if (i == DialogResult.OK)
            {
                _project._contactslistone.Add(UpdatedDate._contactsplus);
                ContactlistBox.Items.Add(UpdatedDate.TxtBox);
                _project.Sort(_project._contactslistone);
            }
            ProjectManager.SaveToFile(_project, _path);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AddContact form2 = new AddContact();
            if (ContactlistBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите контакт для редактирования", "Отсутствие контакта");
            }
            else
            {
                form2.Data._contactsplus = _project._contactslistone[ContactlistBox.SelectedIndex];
                form2.Data.TxtBox = _project._contactslistone[ContactlistBox.SelectedIndex].Surname;
                form2.ShowDialog();
                var UpdatedDate = form2.Data;
                _project._contactslistone.RemoveAt(ContactlistBox.SelectedIndex);
                ContactlistBox.Items.RemoveAt(ContactlistBox.SelectedIndex);
                _project._contactslistone.Add(UpdatedDate._contactsplus);
                ContactlistBox.Items.Add(UpdatedDate.TxtBox);
                NameTextBox1.Text = UpdatedDate._contactsplus.Name;
                SecondNameTextBox1.Text = UpdatedDate._contactsplus.Surname;
                EmailTextBox1.Text = UpdatedDate._contactsplus.Email;
                VKTextBox1.Text = UpdatedDate._contactsplus.IdVk;
                BirthTimePicker1.Value = UpdatedDate._contactsplus.Birth;
                PhoneTextBox1.Text = Convert.ToString(UpdatedDate._contactsplus.Phone.Number);
                _project.Sort(_project._contactslistone);
            }
            ProjectManager.SaveToFile(_project, _path);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactlistBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите контакт для удаления ", "Отсутствие записи");
            }
            else
            {
                var i = MessageBox.Show("Удалить этот контакт?", "Подтверждение", MessageBoxButtons.OKCancel);
                if (i == DialogResult.OK)
                {
                    _project._contactslistone.RemoveAt(ContactlistBox.SelectedIndex);
                    ContactlistBox.Items.RemoveAt(ContactlistBox.SelectedIndex);
                    NameTextBox1.Clear();
                    SecondNameTextBox1.Clear();
                    EmailTextBox1.Clear();
                    PhoneTextBox1.Clear();
                    VKTextBox1.Clear();
                    BirthTimePicker1.Value = BirthTimePicker1.MaxDate;
                }
                ProjectManager.SaveToFile(_project, _path);
            }
        }



        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new AddContact();
            var UpdatedDate = form2.Data;
            var i = form2.ShowDialog();
            if (i == DialogResult.OK)
            {
                _project._contactslistone.Add(UpdatedDate._contactsplus);
                ContactlistBox.Items.Add(UpdatedDate.TxtBox);
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddContact form2 = new AddContact();

            if (ContactlistBox.SelectedIndex >= 0)
            {
                form2.Data._contactsplus = _project._contactslistone[ContactlistBox.SelectedIndex];
                form2.Data.TxtBox = _project._contactslistone[ContactlistBox.SelectedIndex].Surname;
                form2.ShowDialog();
                var UpdatedDate = form2.Data;
                _project._contactslistone.RemoveAt(ContactlistBox.SelectedIndex);
                ContactlistBox.Items.RemoveAt(ContactlistBox.SelectedIndex);
                _project._contactslistone.Add(UpdatedDate._contactsplus);
                ContactlistBox.Items.Add(UpdatedDate.TxtBox);
                NameTextBox1.Text = UpdatedDate._contactsplus.Name;
                SecondNameTextBox1.Text = UpdatedDate._contactsplus.Surname;
                EmailTextBox1.Text = UpdatedDate._contactsplus.Email;
                VKTextBox1.Text = UpdatedDate._contactsplus.IdVk;
                BirthTimePicker1.Value = UpdatedDate._contactsplus.Birth;
                PhoneTextBox1.Text = Convert.ToString(UpdatedDate._contactsplus.Phone.Number);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactlistBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите контакт для удаления ", "Отсутствие записи");
            }
            else
            {
                var i = MessageBox.Show("Удалить этот контакт?", "Подтверждение", MessageBoxButtons.OKCancel);
                if (i == DialogResult.OK)
                {
                    _project._contactslistone.RemoveAt(ContactlistBox.SelectedIndex);
                    ContactlistBox.Items.RemoveAt(ContactlistBox.SelectedIndex);
                    NameTextBox1.Clear();
                    SecondNameTextBox1.Clear();
                    EmailTextBox1.Clear();
                    PhoneTextBox1.Clear();
                    VKTextBox1.Clear();
                    BirthTimePicker1.Value = BirthTimePicker1.MaxDate;
                }
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form3 = new AboutForm();
            form3.ShowDialog();
        }

        private void ContactlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactlistBox.SelectedIndex >= 0)
            {
                Contact _contactsplus;
                _contactsplus = _project._contactslistone[ContactlistBox.SelectedIndex];
                NameTextBox1.Text = _contactsplus.Name;
                SecondNameTextBox1.Text = _contactsplus.Surname;
                EmailTextBox1.Text = _contactsplus.Email;
                VKTextBox1.Text = _contactsplus.IdVk;
                BirthTimePicker1.Value = _contactsplus.Birth;
                PhoneTextBox1.Text = Convert.ToString(_contactsplus.Phone.Number);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}