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
    public partial class AddContact : Form
    {
        private Contact _contactsplus = new Contact();
        private PhoneNumber _phone = new PhoneNumber();

        /*	public Contact Contact
			{
				get { return _contactsplus; }
				set
				{
					_contactsplus = new Contact();
					_contactsplus.Sername = value.Sername;
					_contactsplus.Name = value.Name;
					_contactsplus.Phone = value.Phone;
					_contactsplus.Birth = value.Birth;
					_contactsplus.Email = value.Email;
					_contactsplus.IdVk = value.IdVk;
				}
			} 
			*/
        public AddContact()
        {
            InitializeComponent();
            BirthTimePicker1.MaxDate = DateTime.Now;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Add()
        {
            bool flag;
            try
            {
                flag = true;
                _phone.Number = System.Int64.Parse(PhoneTextBox1.Text);
                _contactsplus.Surname = SecondNameTextBox1.Text;
                _contactsplus.Name = NameTextBox1.Text;
                _contactsplus.Birth = BirthTimePicker1.Value;
                _contactsplus.Phone = _phone;
                _contactsplus.Email = EmailTextBox1.Text;
                _contactsplus.IdVk = VKTextBox1.Text;
                _data.TxtBox = _contactsplus.Surname;
                _data._contactsplus = _contactsplus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный ввод данных");
                flag = false;
            }
            if (flag == true)
            {
                this.Close();
                DialogResult = DialogResult.OK;

            }
        }

        private void Cancel()
        {
            MainForm main = this.Owner as MainForm;
            var form1 = new MainForm();
            if (main != null)
            {
                Data = null;
            }
            this.Close();
        }

        public class DataInMainForm
        {
            public string TxtBox;
            public Contact _contactsplus;
        }

        private DataInMainForm _data = new DataInMainForm();
        public DataInMainForm Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        private void AddContact_Load_1(object sender, EventArgs e)
        {
            if (Data._contactsplus != null)
            {
                SecondNameTextBox1.Text = Data._contactsplus.Surname;
                NameTextBox1.Text = Data._contactsplus.Name;
                EmailTextBox1.Text = Data._contactsplus.Email;
                VKTextBox1.Text = Data._contactsplus.IdVk;
                BirthTimePicker1.Value = Data._contactsplus.Birth;
                PhoneTextBox1.Text = Convert.ToString(Data._contactsplus.Phone.Number);
            }
        }

        private void SecondNameTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.Surname = SecondNameTextBox1.Text;
                SecondNameTextBox1.BackColor = Color.White;
            }
            catch (Exception)
            {
                SecondNameTextBox1.BackColor = Color.Red;
            }
        }

        private void NameTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.Name = NameTextBox1.Text;
                NameTextBox1.BackColor = Color.White;
            }
            catch (Exception)
            {
                NameTextBox1.BackColor = Color.Red;
            }
        }

        private void PhoneTextBox1_TextChanged(object sender, EventArgs e)
        {
            long number;
            try
            {
                long.TryParse(PhoneTextBox1.Text, out number);
                _contactsplus.Phone.Number = number;
                PhoneTextBox1.BackColor = Color.White;
            }
            catch (Exception)
            {
                PhoneTextBox1.BackColor = Color.White;
            }
        }

        private void EmailTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.Email = EmailTextBox1.Text;
                EmailTextBox1.BackColor = Color.White;
            }
            catch (Exception)
            {
                EmailTextBox1.BackColor = Color.Red;
            }
        }

        private void VKTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.IdVk = VKTextBox1.Text;
                VKTextBox1.BackColor = Color.White;
            }
            catch (Exception)
            {
                VKTextBox1.BackColor = Color.Red;
            }
        }

        private void BirthTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contactsplus.Birth = BirthTimePicker1.Value;
                BirthTimePicker1.BackColor = Color.White;

            }
            catch (Exception)
            {
                BirthTimePicker1.BackColor = Color.Red;

            }
        }
        /// <summary>
        /// Заполнение формы для редактирования
        /// </summary>

    }
}
