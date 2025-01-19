using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс, представляющий контакт.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Contact : System.ICloneable
    {
        private string _name;
        private string _surname;
        private PhoneNumber _phone = new PhoneNumber();
        private DateTime _birth;
        private string _eMail;
        private string _idVk;


        /// <summary>
        /// Возвращает или задает имя контакта.
        /// </summary>
        /// <exception cref="ArgumentException">Имя не может быть пустой и не может превышать 50 символов.</exception>
        [JsonProperty]
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
                    throw new ArgumentException("Имя не может быть пустым и не может превышать 50 символов.");
                _name = char.ToUpper(value[0]) + value.Substring(1);
                _name = value;
            }

        }

        /// <summary>
        /// Возвращает или задает фамилию контакта.
        /// </summary>
        [JsonProperty]
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
                    throw new ArgumentException("Фамилия не может быть пустой и не может превышать 50 символов.");
                _surname = char.ToUpper(value[0]) + value.Substring(1);
                _surname = value;
            }
        }

        /// <summary>
        /// Возвращает или задает телефон контакта.
        /// </summary>
        [JsonProperty]
        public PhoneNumber Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }

        }

        public readonly DateTime dateMin = new DateTime(1900, 01, 01);
        /// <summary>
        /// Возвращает или задает дату рождения контакта.
        /// </summary>
        [JsonProperty]
        public DateTime Birth
        {
            get { return _birth; }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Дата рождения не может быть больше текушей даты");
                }
                if (value.Year < 1900)
                {
                    throw new ArgumentException("Дата рождения не может быть быть меньше 1900 года");
                }
                _birth = value;
            }

        }

        /// <summary>
        /// Возвращает или задает почту контакта.
        /// </summary>
        [JsonProperty]
        public string Email
        {
            get
            {
                return _eMail;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50 || !value.Contains("@"))
                    throw new ArgumentException("E-mail не может быть пустым, не может превышать 50 символов и должен содержать '@'.");
                _eMail = value;
            }
        }

        /// <summary>
        /// Возвращает или задает ID ВКонтакте контакта.
        /// </summary>
        [JsonProperty]
        public string IdVk
        {
            get
            {
                return _idVk;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                    throw new ArgumentException("ID ВКонтакте не может быть пустым и не может превышать 15 символов.");
                _idVk = value;
            }
        }


        /// <summary>
        /// Создает копию текущего объекта контакта.
        /// </summary>
        /// <returns>Копия текущего объекта контакта.</returns>
        public object Clone()
        {
            return new Contact
            {
                Name = this.Name,
                Surname = this.Surname,
                Phone = this.Phone,
                Birth = this.Birth,
                Email = this.Email,
                IdVk = this.IdVk
            };
        }


    }
}
