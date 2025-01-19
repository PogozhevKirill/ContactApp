using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс, представляющий номер телефона.
    /// </summary>
    public class PhoneNumber
    {
        private long _number;
        /// <summary>
        /// Возвращает или задает номер телефона.
        /// </summary>
        /// <exception cref="ArgumentException">Номер телефона должен содержать ровно 11 цифр и начинаться с '7'.</exception>
        public long Number
        {
            get { return _number; }

            set
            {
                string numberStr = value.ToString();
                if (numberStr.Length != 11 || numberStr[0] != '7' || !long.TryParse(numberStr, out _))
                {
                    throw new ArgumentException("Номер телефона должен содержать ровно 11 цифр и начинаться с '7'.");
                }
                _number = value;
            }

        }
    }
}
